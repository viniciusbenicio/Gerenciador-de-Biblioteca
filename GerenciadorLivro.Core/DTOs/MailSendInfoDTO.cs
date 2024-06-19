namespace GerenciadorLivro.Core.DTOs
{
    public class MailSendInfoDTO
    {
        public MailSendInfoDTO(int idMail, string toName, string toEmail, string subject, string body, string fromName, string fromEmail)
        {
            IdMail = idMail;
            this.toName = toName;
            this.toEmail = toEmail;
            this.subject = subject;
            this.body = body;
            this.fromName = fromName;
            this.fromEmail = fromEmail;
        }

        public int IdMail { get; set; }
        public string toName { get; set; } = string.Empty;
        public string toEmail { get; set; } = string.Empty;
        public string subject { get; set; } = string.Empty;
        public string body { get; set; } = string.Empty;
        public string fromName { get; set; } = string.Empty;
        public string fromEmail { get; set; } = string.Empty;
    }
}
