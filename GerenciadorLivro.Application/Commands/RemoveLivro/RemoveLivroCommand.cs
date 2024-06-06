using MediatR;

namespace GerenciadorLivro.Application.Commands.RemoveLivro
{
    public class RemoveLivroCommand : IRequest<int>
    {
        public RemoveLivroCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
