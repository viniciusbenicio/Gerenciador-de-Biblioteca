using GerenciadorLivro.Core.Entites;
using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Commands.CreateEmprestimo
{
    public class CreateEmprestimoCommandHandler : IRequestHandler<CreateEmprestimoCommand>
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        public CreateEmprestimoCommandHandler(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }
        public async Task Handle(CreateEmprestimoCommand request, CancellationToken cancellationToken)
        {
            var emprestimo = new Emprestimo(request.IdUsuario, request.IdLivro);

            await _emprestimoRepository.RealizarEmprestimo(emprestimo.IdLivro, emprestimo.IdUsuario);
        }
    }
}
