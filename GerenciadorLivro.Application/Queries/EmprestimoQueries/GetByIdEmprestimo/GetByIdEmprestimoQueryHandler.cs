using GerenciadorLivro.Application.ViewModels.EmprestimoViewModels;
using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Queries.EmprestimoQueries.GetByIdEmprestimo
{
    public class GetByIdEmprestimoQueryHandler : IRequestHandler<GetByIdEmprestimoQuery, EmprestimoViewModel>
    {
        private readonly IEmprestimoRepository _repository;
        public GetByIdEmprestimoQueryHandler(IEmprestimoRepository repository)
        {
            _repository = repository;
        }
        public async Task<EmprestimoViewModel> Handle(GetByIdEmprestimoQuery request, CancellationToken cancellationToken)
        {
            var emprestimo = await _repository.GetByIdAsync(request.Id);

            var emprestimoViewModel = new EmprestimoViewModel();

            return emprestimoViewModel;
        }
    }
}
