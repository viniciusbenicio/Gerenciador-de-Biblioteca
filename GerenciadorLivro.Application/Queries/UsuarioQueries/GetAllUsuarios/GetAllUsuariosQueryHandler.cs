using GerenciadorLivro.Application.ViewModels.UsuarioViewModel;
using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Queries.UsuarioQueries.GetAllUsuarios
{
    public class GetAllUsuariosQueryHandler : IRequestHandler<GetAllUsuariosQuery, List<UsuarioViewModel>>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public GetAllUsuariosQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<List<UsuarioViewModel>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.GetAllAsync();

            var usuarioViewModel = usuarios.Select(u => new UsuarioViewModel(u.Nome, u.Email));

            return usuarioViewModel.ToList();
        }
    }
}
