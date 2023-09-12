namespace OneXBet.Services.Service.Contracts;

public interface IUnitOfServices
{
    IEmailService EmailService { get; }
    IHttpContextService HttpContextService { get; }
}
