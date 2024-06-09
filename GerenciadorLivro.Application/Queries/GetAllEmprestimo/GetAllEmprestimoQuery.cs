using GerenciadorLivro.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace GerenciadorLivro.Application.Queries.GetAllEmpresitmo
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
