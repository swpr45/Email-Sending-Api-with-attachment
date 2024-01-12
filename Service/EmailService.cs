using MailApi.Helper;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Text;

namespace MailApi.Service
{
    public class EmailService : IEmailService
    {
        private readonly EmailSetting emailSettings;

        public EmailService(IOptions<EmailSetting> options)
        {
            this.emailSettings = options.Value;
        }

      
        public async Task SendEmailAsync(MailRequest request)
        {
             var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(emailSettings.Email);
            email.To.Add(MailboxAddress.Parse(request.ToEmail));
            email.Subject = request.Subject;
            var builder = new BodyBuilder();

            if (!string.IsNullOrEmpty(request.AttachedPath) && File.Exists(request.AttachedPath))
            {
                byte[] fileBytes;
                using (var file = new FileStream(request.AttachedPath, FileMode.Open, FileAccess.Read))
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }
                }

                builder.Attachments.Add(request.AttachedPath, fileBytes, ContentType.Parse("application/octet-stream"));
            }
            builder.HtmlBody = request.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();
         
            await smtp.ConnectAsync(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailSettings.Email, emailSettings.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);

         

            
        }
    }
}
