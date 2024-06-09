using GerenciadorLivro.Application.ViewModels.EmprestimoViewModels;
using MediatR;
using System.Collections.Generic;

namespace GerenciadorLivro.Application.Queries.EmprestimoQueries.GetAllEmprestimo
{
    public class GetAllEmprestimoQuery : IRequest<List<EmprestimoViewModel>>
    {
        public GetAllEmprestimoQuery(string query)
        {
            Query = query;
        }

        public string Query { get; set; }
    }
}
