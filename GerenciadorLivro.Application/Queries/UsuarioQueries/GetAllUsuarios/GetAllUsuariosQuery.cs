using GerenciadorLivro.Application.ViewModels.UsuarioViewModel;
using MediatR;
using System.Collections.Generic;

namespace GerenciadorLivro.Application.Queries.UsuarioQueries.GetAllUsuarios
{
    public class GetAllUsuariosQuery : IRequest<List<UsuarioViewModel>>
    {
        public GetAllUsuariosQuery(string query)
        {
            Query = query;
        }

        public string Query { get; set; }
    }
}
