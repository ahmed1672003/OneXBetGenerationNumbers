namespace OneXBet.Services.Service;

public sealed class UnitOfServices : IUnitOfServices
{
    public IEmailService EmailService { get; private set; }
    public IHttpContextService HttpContextService { get; private set; }

    public UnitOfServices(IEmailService emailService, IHttpContextService httpContextService)
    {
        EmailService = emailService;
        HttpContextService = httpContextService;
    }
}
