using GerenciadorLivro.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace GerenciadorLivro.Application.Queries.GetByIdLivro
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
