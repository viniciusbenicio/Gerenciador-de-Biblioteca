using GerenciadorLivro.Application.Queries.GetByIdUsuario;
using GerenciadorLivro.Application.ViewModels;
using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Queries.GetByIdUsuario
{
    public class GetByIdUsuarioQueryHandler : IRequestHandler<GetByIdUsuarioQuery, UsuarioViewModel>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public GetByIdUsuarioQueryHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<UsuarioViewModel> Handle(GetByIdUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.Id);

            var usuarioViewModel = new UsuarioViewModel(usuario.Nome, usuario.Email);

            return usuarioViewModel;
        }
    }
}
