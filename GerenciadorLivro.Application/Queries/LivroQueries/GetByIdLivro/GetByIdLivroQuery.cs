using GerenciadorLivro.Application.ViewModels.LivroViewModel;
using MediatR;
using System.Collections.Generic;

namespace GerenciadorLivro.Application.Queries.LivroQueries.GetByIdLivro
{
    public class GetByIdLivroQuery : IRequest<LivroViewModel>
    {
        public GetByIdLivroQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
