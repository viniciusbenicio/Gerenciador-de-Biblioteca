using GerenciadorLivro.Core.DTOs;
using GerenciadorLivro.Core.Entites;
using GerenciadorLivro.Core.Repositories;
using GerenciadorLivro.Core.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Commands.EmprestimoCQRS.CreateEmprestimo
{
    public class CreateEmprestimoCommandHandler : IRequestHandler<CreateEmprestimoCommand, int>
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILivroRepository _livroRepository;
        private readonly IMailService _mailService;
        public CreateEmprestimoCommandHandler(IEmprestimoRepository emprestimoRepository, IMailService mailService, IUsuarioRepository usuarioRepository, ILivroRepository livroRepository)
        {
            _emprestimoRepository = emprestimoRepository;
            _mailService = mailService;
            _usuarioRepository = usuarioRepository;
            _livroRepository = livroRepository;
        }
        public async Task<int> Handle(CreateEmprestimoCommand request, CancellationToken cancellationToken)
        {
            var emprestimo = new Emprestimo(request.UsuarioId, request.LivroId);
            var livro = await _livroRepository.GetByIdAsync(request.LivroId); 
            var usuario = await _usuarioRepository.GetByIdAsync(request.UsuarioId);

            await _emprestimoRepository.RealizarEmprestimo(emprestimo.LivroId, emprestimo.UsuarioId, request.PrazoDias);

            var sendMail = new MailSendInfoDTO(1, usuario.Nome, usuario.Email, "Emprestimo Realizado", "Emprestimo do livro: " + livro.Titulo + " Realizado com sucesso, boa Leitura " + usuario.Nome , usuario.Nome, usuario.Email);

            _mailService.SendMail(sendMail);

            await _emprestimoRepository.SaveChangesAsync();

            return emprestimo.LivroId;
        }
    }
}
