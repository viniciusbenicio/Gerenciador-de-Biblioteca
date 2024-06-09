using GerenciadorLivro.Core.Entites;
using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Commands.EmprestimoCQRS.CreateEmprestimo
{
    public class CreateEmprestimoCommandHandler : IRequestHandler<CreateEmprestimoCommand, int>
    {
        private readonly IEmprestimoRepository _emprestimoRepository;
        public CreateEmprestimoCommandHandler(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }
        public async Task<int> Handle(CreateEmprestimoCommand request, CancellationToken cancellationToken)
        {
            var emprestimo = new Emprestimo(request.UsuarioId, request.LivroId);

            await _emprestimoRepository.RealizarEmprestimo(emprestimo.LivroId, emprestimo.UsuarioId);

            return emprestimo.LivroId;
        }
    }
}
