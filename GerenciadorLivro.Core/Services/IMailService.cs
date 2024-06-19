using GerenciadorLivro.Core.DTOs;

namespace GerenciadorLivro.Core.Services
{
    public interface IMailService
    {
        void SendMail(MailSendInfoDTO mailSendInfoDTO);
    }
}
