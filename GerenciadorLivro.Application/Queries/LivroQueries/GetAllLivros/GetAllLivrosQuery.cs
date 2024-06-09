using GerenciadorLivro.Application.ViewModels.LivroViewModel;
using MediatR;
using System.Collections.Generic;

namespace GerenciadorLivro.Application.Queries.LivroQueries.GetAllLivros
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
