using MediatR;

namespace GerenciadorLivro.Application.Commands.CreateUsuario
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
    }
}
