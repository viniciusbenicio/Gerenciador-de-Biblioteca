using GerenciadorLivro.Core.Entites;
using GerenciadorLivro.Core.Repositories;
using System.Threading.Tasks;

namespace GerenciadorLivro.Infrastructure.Persistence.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GerenciadorLivroDbContext _context;
        public UsuarioRepository(GerenciadorLivroDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

        }
    }
}
