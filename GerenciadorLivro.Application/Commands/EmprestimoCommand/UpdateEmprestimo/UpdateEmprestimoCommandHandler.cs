using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Commands.EmprestimoCQRS.UpdateEmprestimo
{
    public class UpdateUsuarioCommandHandler : IRequestHandler<UpdateEmprestimoCommand, int>
    {
        private readonly IEmprestimoRepository _repository;
        public UpdateUsuarioCommandHandler(IEmprestimoRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(UpdateEmprestimoCommand request, CancellationToken cancellationToken)
        {
            var emprestimo = await _repository.GetByIdAsync(request.Id);

            emprestimo.Atualizar(request.IdLivro, request.DataEmprestimo);

            _repository.Update(emprestimo);

            return emprestimo.Id;
        }
    }
}
