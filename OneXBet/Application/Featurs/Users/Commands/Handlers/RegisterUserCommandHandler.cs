using AutoMapper;

using Microsoft.AspNetCore.WebUtilities;

using OneXBet.Infrastructure.Specifications.Users;

namespace OneXBet.Application.Featurs.Users.Commands.Handlers;

public sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, (bool statues, string message)>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfServices _services;
    private readonly IUnitOfWork _context;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    public RegisterUserCommandHandler(IMapper mapper, IUnitOfWork context, IUnitOfServices services, IStringLocalizer<SharedResources> stringLocalizer)
    {
        _mapper = mapper;
        _context = context;
        _services = services;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<(bool statues, string message)> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            return (false, _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

        // Map to user
        var user = _mapper.Map<User>(request.ViewModel);
        try
        {
            // check email is exist or not ?
            var emailExistSpec = EmailExistSpecification.Create(user.Email);
            if (await _context.Users.AnyAsync(emailExistSpec, cancellationToken))
                return (false, _stringLocalizer[ResourcesKeys.User.EmailAllreadyExist]);

            // check user name is exist or not ?
            var userNameExistSpec = UserNameExistSpecification.Create(user.UserName);
            if (await _context.Users.AnyAsync(userNameExistSpec, cancellationToken))
                return (false, _stringLocalizer[ResourcesKeys.User.UserNameAllreadyExist]);

            var phoneNumberExistSpec = PhoneNumberExistSpecification.Create(user.PhoneNumber);
            if (await _context.Users.AnyAsync(phoneNumberExistSpec, cancellationToken))
                return (false, _stringLocalizer[ResourcesKeys.User.PhoneNumberAllreadyExist]);

            await _context.Identity.UserStore.SetUserNameAsync(user, user.UserName, cancellationToken);
            await _context.Identity.UserEmailStore.SetEmailAsync(user, user.Email, cancellationToken);

            var result = await _context.Identity.UserManager.CreateAsync(user, request.ViewModel.Password);

            // check registeration proccess is success or not ?
            if (!result.Succeeded)
                return (false, _stringLocalizer[ResourcesKeys.User.CreateUserFailed]);

            #region Send Email 
            var token = await _context.Identity.UserManager.GenerateEmailConfirmationTokenAsync(user);

            // send to confirm email address
            var url = $"{_services.HttpContextService.ContextAccessor.HttpContext.Request.Scheme.Trim().ToLower()}://{_services.HttpContextService.ContextAccessor.HttpContext.Request.Host.ToUriComponent().Trim().ToLower()}/Auth/SinInUser";

            var parameters = new Dictionary<string, string>
            {
                {"token",token},
                { "userId" , user.Id.ToString()}
            };

            var newUrl = new Uri(QueryHelpers.AddQueryString(url, parameters));

            var sendEmailResult = await _services.EmailService.SendEmailAsync(user.Email, "Confirm your email", newUrl.ToString());

            #endregion

            return (true, _stringLocalizer[ResourcesKeys.User.CreateUserSuccess]);
        }
        catch
        {
            return (false, _stringLocalizer[ResourcesKeys.Shared.ServerError]);
        }
    }
}
