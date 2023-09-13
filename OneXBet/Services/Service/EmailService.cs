using MailKit.Net.Smtp;
using MailKit.Security;

using Microsoft.Extensions.Options;

using MimeKit;

using OneXBet.Infrastructure.Specifications.Users;

namespace OneXBet.Services.Service;

public sealed class EmailService : IEmailService
{
    private readonly EmailSettings _emailSettings;
    private readonly IUnitOfWork _context;
    public EmailService(IOptions<EmailSettings> options, IHttpContextAccessor httpContextAccessor, IUnitOfWork context)
    {
        _emailSettings = options.Value;
        _context = context;
    }

    public async Task<bool>
       SendEmailAsync(string mailTo, string subject, string body, IReadOnlyList<IFormFile> attachments = null)
    {
        try
        {
            var htmlPage =
                @"<html>
                  <head>
                    <style>
                    .card {
                            padding: 10px;
                            background-color: #eee;
                            min-height: 80px;
                            max-width: 50%;
                            margin: auto;
                            display: flex;
                            justify-content: center;
                            align-items: center;
                            border-radius: 20px;
                        }
                     .link {
                            text-decoration: none;
                            padding: 10px;
                            background: #61c261;
                            border-radius: 23px;
                            color: white;
                            font-family: cursive;
                        }
                    </style>
                  </head>
                  <body>
                    <div class='card'>
                        <a class='link' href= > Confirm Email </a>
                    </div>
                  </body>
                </html>";
            htmlPage = htmlPage.Replace("href=", $"href={body}");

            // build body
            var bodyBuilder = new BodyBuilder()
            {
                //HtmlBody = $"<a href={body}> Confirm Email</a>",
                HtmlBody = htmlPage,
            };

            if (attachments != null)
            {
                byte[] fileBytes;

                foreach (var file in attachments)
                {
                    if (file.Length > 0)
                    {
                        using var ms = new MemoryStream();
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();

                        // add files
                        bodyBuilder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }

            // create email 
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_emailSettings.Sender),
                Subject = subject,
                Body = bodyBuilder.ToMessageBody(),
            };

            email.To.Add(MailboxAddress.Parse(mailTo));
            email.From.Add(new MailboxAddress(_emailSettings.DisplayName, _emailSettings.Sender));

            // connect to smtp
            using var smtp = new SmtpClient();

            smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.SslOnConnect);
            smtp.Authenticate(_emailSettings.Sender, _emailSettings.Password);
            var serviceMessage = await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);

            return true;

        }
        catch
        {
            return false;
        }
    }

    public async Task<(bool statues, int? userId)> ConfirmEmailAsync(string userId, string token)
    {
        if (string.IsNullOrEmpty(userId) || string.IsNullOrWhiteSpace(userId) ||
            string.IsNullOrEmpty(token) || string.IsNullOrWhiteSpace(token))
            return (false, null);

        if (!int.TryParse(userId, out int id))
            return (false, null);

        var getUserByIdSpec = GetUserByEmailSpecification.Create(id);
        var user = await _context.Identity.UserManager.FindByIdAsync(userId);

        if (user is null)
            return (false, null);

        var result = await _context.Identity.UserManager.ConfirmEmailAsync(user, token);

        if (!result.Succeeded)
            return (false, null);

        //await _context.Identity.SignInManager.SignInAsync(user, true);

        return (true, user.Id);
    }
}
