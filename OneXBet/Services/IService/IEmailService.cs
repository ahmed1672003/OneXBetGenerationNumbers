namespace OneXBet.Services.IService;

public interface IEmailService
{
    Task<bool>
        SendEmailAsync(string mailTo, string subject, string body, IReadOnlyList<IFormFile> attachments = null);
}