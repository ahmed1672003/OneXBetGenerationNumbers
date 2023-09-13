using OneXBet.Infrastructure.Specifications.Users;

namespace OneXBet.Application.Featurs.Users.Queries.Handlers;

public sealed class SignInUserQueryHandler : IRequestHandler<SignInUserQuery, (bool status, string message)>
{
    private readonly IUnitOfWork _context;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IUnitOfServices _services;

    public SignInUserQueryHandler(IUnitOfWork context, IStringLocalizer<SharedResources> stringLocalizer, IHttpClientFactory httpClientFactory, IUnitOfServices services)
    {
        _context = context;
        _stringLocalizer = stringLocalizer;
        _httpClientFactory = httpClientFactory;
        _services = services;
    }

    public async Task<(bool status, string message)> Handle(SignInUserQuery request, CancellationToken cancellationToken)
    {
        if (request == null)
            return (false, _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

        try
        {
            using var httpClient = _httpClientFactory.CreateClient();

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var url = new Uri($"{_services.HttpContextService.ContextAccessor.HttpContext.Request.Scheme.Trim().ToLower()}://{_services.HttpContextService.ContextAccessor.HttpContext.Request.Host.ToUriComponent().Trim().ToLower()}/api/Email/ConfirmEmail/");
            var clientMessage = await httpClient.PatchAsJsonAsync(url, request.ViewModel);

            if (!clientMessage.IsSuccessStatusCode)
                return (false, _stringLocalizer[ResourcesKeys.User.SignInSuccess]);

            var userIdResponse = await clientMessage.Content.ReadFromJsonAsync<int>();

            var getUserByIdSpec = GetUserByIdSpecification.Create(userIdResponse);

            // get user by id and make him sign in

            if (!await _context.Users.AnyAsync(getUserByIdSpec))
                return (false, _stringLocalizer[ResourcesKeys.User.UserByEmailNotFound]);

            var user = await _context.Users.RetrieveAsync(getUserByIdSpec);

            if (!await _context.Identity.SignInManager.CanSignInAsync(user))
                return (false, _stringLocalizer[ResourcesKeys.User.SignInFailed]);

            await _context.Identity.SignInManager.SignInAsync(user, true);

            return (true, _stringLocalizer[ResourcesKeys.User.SignInSuccess]);

        }
        catch
        {
            return (false, _stringLocalizer[ResourcesKeys.Shared.ServerError]);
        }
    }
}
