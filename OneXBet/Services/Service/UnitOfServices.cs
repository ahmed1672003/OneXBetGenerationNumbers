using OneXBet.Services.IService;

namespace OneXBet.Services.Service;

public class UnitOfServices : IUnitOfServices
{
    public IEmailService EmailService { get; private set; }

    public UnitOfServices(IEmailService emailService)
    {
        EmailService = emailService;
    }
}
