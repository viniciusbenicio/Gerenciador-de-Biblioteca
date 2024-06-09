using GerenciadorLivro.Application.ViewModels.LivroViewModel;
using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Queries.LivroQueries.GetAllLivros
{
    public class GetAllLivrosQueryHandler : IRequestHandler<GetAllLivrosQuery, List<LivroViewModel>>
    {
        private readonly ILivroRepository _livroRepository;
        public GetAllLivrosQueryHandler(ILivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }
        public async Task<List<LivroViewModel>> Handle(GetAllLivrosQuery request, CancellationToken cancellationToken)
        {
            var livros = await _livroRepository.GetAllAsync();

            var livroViewModel = livros.Where(l => l.Ativo == true).Select(l => new LivroViewModel(l.Titulo, l.Autor, l.ISBN, l.AnoPublicacao, l.Ativo));

            return livroViewModel.ToList();
        }
    }
}
