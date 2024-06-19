using GerenciadorLivro.Core.DTOs;
using GerenciadorLivro.Core.Entites;
using GerenciadorLivro.Core.Repositories;
using GerenciadorLivro.Core.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Commands.EmprestimoCQRS.CreateEmprestimo
{
    public class CreateEmprestimoCommandHandler : IRequestHandler<CreateEmprestimoCommand, int>
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IMailService _mailService;
        public CreateEmprestimoCommandHandler(IEmprestimoRepository emprestimoRepository, IMailService mailService)
        {
            _emprestimoRepository = emprestimoRepository;
            _mailService = mailService;
        }
        public async Task<int> Handle(CreateEmprestimoCommand request, CancellationToken cancellationToken)
        {
            var emprestimo = new Emprestimo(request.UsuarioId, request.LivroId);

            await _emprestimoRepository.RealizarEmprestimo(emprestimo.LivroId, emprestimo.UsuarioId, request.PrazoDias);

            var mailAd = new MailSendInfoDTO(1,"Vinicius","vinicius.benicio97@gmail.com", "Teste", "Teste",
                "Teste", "vinicius.benicio97@gmail.com");

            _mailService.SendMail(mailAd);

            return emprestimo.LivroId;
        }
    }
}
