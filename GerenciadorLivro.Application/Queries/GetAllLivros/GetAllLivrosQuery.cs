using GerenciadorLivro.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace GerenciadorLivro.Application.Queries.GetAllLivros
{
    public class GetAllLivrosQuery : IRequest<List<LivroViewModel>>
    {
        public GetAllLivrosQuery(string query)
        {
            Query = query;
        }
        
        public string Query { get; set; }
    }
}
