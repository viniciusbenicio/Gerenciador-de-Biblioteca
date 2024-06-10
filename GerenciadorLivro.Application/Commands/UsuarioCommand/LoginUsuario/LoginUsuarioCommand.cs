using GerenciadorLivro.Application.ViewModels.UsuarioViewModel;
using MediatR;

namespace GerenciadorLivro.Application.Commands.UsuarioCommand.LoginUsuario
{
    public class LoginUsuarioCommand : IRequest<LoginUsuarioViewModel>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
