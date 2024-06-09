using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Commands.RemoveUsuario
{
    public class RemoveUsuarioCommandHandler : IRequestHandler<RemoveUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public RemoveUsuarioCommandHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public async Task<int> Handle(RemoveUsuarioCommand request, CancellationToken cancellationToken)
        {
            var id = await _usuarioRepository.RemoveAsync(request.Id);

            return id;

        }
    }
}
