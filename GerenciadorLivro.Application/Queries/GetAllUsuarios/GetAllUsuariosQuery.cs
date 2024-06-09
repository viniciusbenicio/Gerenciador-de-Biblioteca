using GerenciadorLivro.Application.ViewModels;
using MediatR;
using System.Collections.Generic;

namespace GerenciadorLivro.Application.Queries.GetAllUsuarios
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
