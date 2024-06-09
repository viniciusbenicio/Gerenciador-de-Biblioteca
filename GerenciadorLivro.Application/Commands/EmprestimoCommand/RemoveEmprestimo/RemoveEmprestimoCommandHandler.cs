using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Commands.EmprestimoCQRS.RemoveEmprestimo
{
    public class RemoveEmprestimoCommandHandler : IRequestHandler<RemoveEmprestimoCommand, int>
    {
        private readonly IEmprestimoRepository _repository;
        public RemoveEmprestimoCommandHandler(IEmprestimoRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(RemoveEmprestimoCommand request, CancellationToken cancellationToken)
        {
            var id = await _repository.RemoveAsync(request.Id);

            return id;

        }
    }
}
