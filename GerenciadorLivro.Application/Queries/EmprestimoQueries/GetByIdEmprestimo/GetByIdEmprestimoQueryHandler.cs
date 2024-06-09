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
            string mensagem = string.Empty;
            var prazoAtraso = _repository.CalcularPrazoEmprestimo(emprestimo);

            mensagem = prazoAtraso > 0
                 ? $"Seu empréstimo está com {prazoAtraso} dias de atraso para devolução, favor realizar devolução ou renove seu empréstimo"
                 : $"Seu empréstimo está em dia";

            var emprestimoViewModel = new EmprestimoViewModel(emprestimo.Usuario.Nome, emprestimo.Livro.Titulo, emprestimo.DataEmprestimo, emprestimo.DataDevolucao, mensagem);

            return emprestimoViewModel;
        }
    }
}
