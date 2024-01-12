using System.ComponentModel;


namespace MailApi.Helper
{
    public class MailRequest
    {
        [DisplayName("Mail To")]
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
       
        
        [DisplayName("Attachement path")]
        public string? AttachedPath { get ;set ; }

        public byte[]? Attachment { get; set; }
    }
}
