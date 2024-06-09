using GerenciadorLivro.Application.ViewModels;
using MediatR;

namespace GerenciadorLivro.Application.Queries.GetByIdUsuario
{
    public class GetByIdUsuarioQuery : IRequest<UsuarioViewModel>
    {
        public GetByIdUsuarioQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
