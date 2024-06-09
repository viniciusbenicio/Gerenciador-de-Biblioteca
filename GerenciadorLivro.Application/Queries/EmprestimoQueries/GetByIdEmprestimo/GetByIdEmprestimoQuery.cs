using GerenciadorLivro.Application.ViewModels;
using MediatR;

namespace GerenciadorLivro.Application.Queries.EmprestimoQueries.GetByIdEmprestimo
{
    public class GetByIdEmprestimoQuery : IRequest<EmprestimoViewModel>
    {
        public GetByIdEmprestimoQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
