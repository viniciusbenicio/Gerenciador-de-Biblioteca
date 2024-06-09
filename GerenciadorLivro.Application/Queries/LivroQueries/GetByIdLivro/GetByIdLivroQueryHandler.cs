using GerenciadorLivro.Application.ViewModels.LivroViewModel;
using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Queries.LivroQueries.GetByIdLivro
{
    public class GetByIdLivroQueryHandler : IRequestHandler<GetByIdLivroQuery, LivroViewModel>
    {
        private readonly ILivroRepository _livroRepository;
        public GetByIdLivroQueryHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }
        public async Task<LivroViewModel> Handle(GetByIdLivroQuery request, CancellationToken cancellationToken)
        {
            var livro = await _livroRepository.GetByIdAsync(request.Id);

            var livroViewModels = new LivroViewModel(livro.Titulo, livro.Autor, livro.ISBN, livro.AnoPublicacao, livro.Ativo);

            return livroViewModels;
        }
    }
}
