using GerenciadorLivro.Core.Entites;
using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Commands.UsuarioCQRS.CreateUsuario
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _repository;
        private readonly IAuthService _authService;

        public CreateUsuarioCommandHandler(IUsuarioRepository repository, IAuthService authService)
        {
            _repository = repository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Senha);

            var usuario = new Usuario(request.Nome, request.Email, passwordHash, request.Role);

            await _repository.AddAsync(usuario);

            return usuario.Id;
        }
    }
}
