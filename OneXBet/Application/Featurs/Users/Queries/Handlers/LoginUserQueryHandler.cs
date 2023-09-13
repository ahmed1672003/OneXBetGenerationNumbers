using OneXBet.Infrastructure.Specifications.Users;

namespace OneXBet.Application.Featurs.Users.Queries.Handlers;

public sealed class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, (bool status, string message)>
{
    private readonly IUnitOfWork _context;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;

    public LoginUserQueryHandler(IUnitOfWork context, IStringLocalizer<SharedResources> stringLocalizer)
    {
        _context = context;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<(bool status, string message)> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        if (request == null)
            return (false, _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

        var emailOrUserNameSpec = GetUserByEmailOrUserNameSpecification.Create(request.ViewModel.EmailOrUserName);

        if (!await _context.Users.AnyAsync(emailOrUserNameSpec, cancellationToken))
            return (false, _stringLocalizer[ResourcesKeys.User.UserByEmailOrUserNameNotFound]);

        var user = await _context.Users.RetrieveAsync(emailOrUserNameSpec, cancellationToken);

        {
            // TO Do: Check Email Confirmed
        }

        var signInResult = await _context.Identity.SignInManager.PasswordSignInAsync(user, request.ViewModel.Password, request.ViewModel.RememberMe, true);

        if (!signInResult.Succeeded)
            return (false, _stringLocalizer[ResourcesKeys.User.SignInFailed]);

        return (true, ResourcesKeys.User.SignInSuccess);
    }
}
