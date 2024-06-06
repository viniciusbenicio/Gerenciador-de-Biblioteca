using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Commands.RemoveLivro
{
    public class RemoveLivroCommandHandler : IRequestHandler<RemoveLivroCommand, int>
    {
        private readonly ILivroRepository _livroRepository;
        public RemoveLivroCommandHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }
        public async Task<int> Handle(RemoveLivroCommand request, CancellationToken cancellationToken)
        {
            var id = await _livroRepository.RemoveAsync(request.Id);

            return id;

        }
    }
}
