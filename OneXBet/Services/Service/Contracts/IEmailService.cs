namespace OneXBet.Services.Service.Contracts;

public interface IEmailService
{
    Task<bool> SendEmailAsync(string mailTo, string subject, string body, IReadOnlyList<IFormFile> attachments = null);

    Task<(bool statues, int? userId)> ConfirmEmailAsync(string userId, string token);
}