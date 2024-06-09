using GerenciadorLivro.Application.ViewModels.UsuarioViewModel;
using MediatR;

namespace GerenciadorLivro.Application.Queries.UsuarioQueries.GetByIdUsuario
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
