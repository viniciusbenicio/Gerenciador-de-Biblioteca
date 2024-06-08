using GerenciadorLivro.Core.Entites;
using GerenciadorLivro.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorLivro.Infrastructure.Persistence.Repositories
{
    public class LivroRepository : ILivroRepository
    {
        public readonly GerenciadorLivroDbContext _context;
        public LivroRepository(GerenciadorLivroDbContext context)
        {
            _context = context;
        }

        public async Task<List<Livro>> GetAllAsync()
        {
            return await _context.Livros.ToListAsync();
        }

        public async Task<Livro> GetByIdAsync(int id)
        {
            return await _context.Livros.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Livro livro)
        {
            await _context.Livros.AddAsync(livro);
            await _context.SaveChangesAsync();
        }
        public void Update(Livro livro)
        {
            _context.Livros.Update(livro);
            _context.SaveChanges(); 
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(int id)
        {
            var livro = await _context.Livros.FirstOrDefaultAsync(x => x.Id == id);
            livro?.Desativar();

            await _context.SaveChangesAsync();

            return livro.Id;
        }
    }
}
