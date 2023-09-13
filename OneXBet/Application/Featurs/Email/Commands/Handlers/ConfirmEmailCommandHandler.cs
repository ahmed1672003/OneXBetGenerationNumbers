namespace OneXBet.Application.Featurs.Email.Commands.Handlers;

public sealed class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, (bool status, string message, int? userId)>
{
    private readonly IUnitOfServices _services;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;

    public ConfirmEmailCommandHandler(IUnitOfServices services, IStringLocalizer<SharedResources> stringLocalizer)
    {
        _services = services;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<(bool status, string message, int? userId)> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
            return (false, _stringLocalizer[ResourcesKeys.Shared.BadRequest], null);
        try
        {
            var result = await _services.EmailService.ConfirmEmailAsync(request.ViewModel.UserId, request.ViewModel.Token);

            if (!result.statues)
                return (false, _stringLocalizer[ResourcesKeys.User.EmailConfirmationFailed], null);

            return (true, _stringLocalizer[ResourcesKeys.User.EmailConfirmationSuccess], result.userId);
        }
        catch
        {
            return (false, _stringLocalizer[ResourcesKeys.Shared.ServerError], null);
        }
    }
}
