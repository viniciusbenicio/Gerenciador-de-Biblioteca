using MediatR;

namespace GerenciadorLivro.Application.Commands.UpdateLivro
{
    public class UpdateLivroCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int AnoPublicacao { get; set; }
    }
}
