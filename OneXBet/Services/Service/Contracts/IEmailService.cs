namespace OneXBet.Services.Service.Contracts;

public interface IEmailService
{
    Task<bool>
        SendEmailAsync(string mailTo, string subject, string body, IReadOnlyList<IFormFile> attachments = null);
}