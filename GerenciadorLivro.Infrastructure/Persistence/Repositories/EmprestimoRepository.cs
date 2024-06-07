using GerenciadorLivro.Core.Entites;
using GerenciadorLivro.Core.Repositories;
using System.Data;
using System.Threading.Tasks;

namespace GerenciadorLivro.Infrastructure.Persistence.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly GerenciadorLivroDbContext _context;
        private readonly ILivroRepository _livroRepository;
        public EmprestimoRepository(GerenciadorLivroDbContext context, ILivroRepository livroRepository)
        {
            _context = context;
            _livroRepository = livroRepository;
        }
        public async Task<Emprestimo> RealizarEmprestimo(int idLivro, int idUsuario)
        {
            var livro = await _livroRepository.GetByIdAsync(idLivro);

            if (livro is null)
                return null;

            var emprestimoLivro = new Emprestimo(idUsuario, livro.Id);
            await _context.Emprestimo.AddAsync(emprestimoLivro);
            await _context.SaveChangesAsync();

            return emprestimoLivro;
        }
    }
}
