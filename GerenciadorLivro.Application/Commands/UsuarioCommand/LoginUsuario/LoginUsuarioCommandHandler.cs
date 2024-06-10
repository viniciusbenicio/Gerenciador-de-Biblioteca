using GerenciadorLivro.Application.ViewModels.UsuarioViewModel;
using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Commands.UsuarioCommand.LoginUsuario
{
    public class LoginUsuarioCommandHandler : IRequestHandler<LoginUsuarioCommand, LoginUsuarioViewModel>
    {
        private readonly IAuthService _authService;
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginUsuarioCommandHandler(IAuthService authService, IUsuarioRepository usuarioRepository)
        {
            _authService = authService;
            _usuarioRepository = usuarioRepository;
        }
        public async Task<LoginUsuarioViewModel> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Senha);

            var user = await _usuarioRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user is null)
                return null;

            var token = _authService.GenerateJwtToken(user.Email, user.Role);

            return new LoginUsuarioViewModel(user.Email, token);
        }
    }
}
