using MediatR;

namespace GerenciadorLivro.Application.Commands.RemoveUsuario
{
    public class RemoveUsuarioCommand : IRequest<int>
    {
        public RemoveUsuarioCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
