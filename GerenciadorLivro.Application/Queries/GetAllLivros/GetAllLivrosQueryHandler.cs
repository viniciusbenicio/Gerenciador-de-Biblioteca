using GerenciadorLivro.Application.ViewModels;
using GerenciadorLivro.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GerenciadorLivro.Application.Queries.GetAllLivros
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

            var livroViewModel = livros.Select(l => new LivroViewModel(l.Titulo, l.Autor, l.ISBN, l.AnoPublicacao, l.Ativo)).ToList();

            return livroViewModel;
        }
    }
}
