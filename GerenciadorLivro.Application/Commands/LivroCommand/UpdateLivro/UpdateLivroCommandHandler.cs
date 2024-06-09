using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Commands.LivroCQRS.UpdateLivro
{
    public class UpdateLivroCommandHandler : IRequestHandler<UpdateLivroCommand, int>
    {
        private readonly ILivroRepository _repository;
        public UpdateLivroCommandHandler(ILivroRepository repository)
        {
            _repository = repository;
        }
        public async Task<int> Handle(UpdateLivroCommand request, CancellationToken cancellationToken)
        {
            var livro = await _repository.GetByIdAsync(request.Id);
            livro.Atualizar(request.Titulo, request.Autor, request.ISBN, request.AnoPublicacao);

            _repository.Update(livro);

            return livro.Id;
        }
    }
}
