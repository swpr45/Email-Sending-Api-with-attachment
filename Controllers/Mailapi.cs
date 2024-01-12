using MailApi.Helper;
using MailApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace MailApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Mailapi : ControllerBase
    {
        private readonly IEmailService _emailservice;
     

        public Mailapi(IEmailService emailService)
        {
            _emailservice = emailService;
        }
        [HttpPost]
        
        public async Task<IActionResult> SendMail([FromForm] MailRequest mr,IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {


                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\", uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);

                    }
                    mr.AttachedPath = filePath;
                }


                /* MailRequest mailRequest = new MailRequest();
                 mailRequest.ToEmail = mr.ToEmail;
                 mailRequest.Subject = mr.Subject;
                 mailRequest.Body = mr.Body;*/

                await _emailservice.SendEmailAsync(mr);
                return Ok("email sended successfully!");
            }
            catch (Exception)
            {

                throw;
            }
           
           
            
        }
    }
}
