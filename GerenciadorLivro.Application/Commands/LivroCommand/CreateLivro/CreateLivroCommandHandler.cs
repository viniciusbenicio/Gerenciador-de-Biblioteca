using GerenciadorLivro.Core.Entites;
using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Commands.LivroCQRS.CreateLivro
{
    public class CreateLivroCommandHandler : IRequestHandler<CreateLivroCommand, int>
    {
        private readonly ILivroRepository _repository;
        public CreateLivroCommandHandler(ILivroRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(CreateLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = new Livro(request.Titulo, request.Autor, request.ISBN, request.AnoPublicacao);
            livro.Ativar();

            await _repository.AddAsync(livro);

            return livro.Id;
        }
    }
}
