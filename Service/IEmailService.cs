using MailApi.Helper;

namespace MailApi.Service
{
    public interface IEmailService
    {
         Task SendEmailAsync(MailRequest request);
    }
}
