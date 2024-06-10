using MediatR;

namespace GerenciadorLivro.Application.Commands.UsuarioCQRS.CreateUsuario
{
    public class CreateUsuarioCommand : IRequest<int>
    {
        public CreateUsuarioCommand(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }
    }
}
