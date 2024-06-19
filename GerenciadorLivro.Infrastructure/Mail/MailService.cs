using GerenciadorLivro.Core.DTOs;
using GerenciadorLivro.Core.Services;
using System.Text;
using System.Text.Json;

namespace GerenciadorLivro.Infrastructure.Mail
{
    public class MailService : IMailService
    {
        private readonly IMessageBusService _messageBusService;
        private const string QUEUE_NAME = "Emails";

        public MailService(IMessageBusService messageBusService)
        {
            _messageBusService = messageBusService;
        }

        public void SendMail(MailSendInfoDTO mailSendInfoDTO)
        {
            var mailSendInfoJson = JsonSerializer.Serialize(mailSendInfoDTO);

            var mailSendInfoBytes = Encoding.UTF8.GetBytes(mailSendInfoJson);

            _messageBusService.Publish(QUEUE_NAME, mailSendInfoBytes);
        }
    }
}
