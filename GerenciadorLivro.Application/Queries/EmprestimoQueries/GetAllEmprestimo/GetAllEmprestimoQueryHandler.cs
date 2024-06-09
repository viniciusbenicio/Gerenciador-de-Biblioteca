using GerenciadorLivro.Application.ViewModels.EmprestimoViewModels;
using GerenciadorLivro.Core.Entites;
using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Queries.EmprestimoQueries.GetAllEmprestimo
{
    public class GetAllEmprestimoQueryHandler : IRequestHandler<GetAllEmprestimoQuery, List<EmprestimoViewModel>>
    {
        private readonly IEmprestimoRepository _repository;
        public GetAllEmprestimoQueryHandler(IEmprestimoRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<EmprestimoViewModel>> Handle(GetAllEmprestimoQuery request, CancellationToken cancellationToken)
        {
            var emprestimos = await _repository.GetAllAsync();
            var emprestimoViewModels = new List<EmprestimoViewModel>();

            foreach (var emp in emprestimos)
            {
                var prazoAtraso = _repository.CalcularPrazoEmprestimo(emp);
                string mensagem = prazoAtraso > 0
                    ? $"Seu empréstimo está com {prazoAtraso} dias de atraso para devolução, favor realizar devolução ou renove seu empréstimo"
                    : $"Seu empréstimo está em dia";

                var emprestimoViewModel = new EmprestimoViewModel(
                    emp.Usuario.Nome,
                    emp.Livro.Titulo,
                    emp.DataEmprestimo,
                    emp.DataDevolucao,
                    mensagem);

                emprestimoViewModels.Add(emprestimoViewModel);
            }

            return emprestimoViewModels;

        }
    }
}
