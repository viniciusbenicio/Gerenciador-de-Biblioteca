using GerenciadorLivro.Core.Entites;
using GerenciadorLivro.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace GerenciadorLivro.Infrastructure.Persistence.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly GerenciadorLivroDbContext _context;
        private readonly IEmprestimoRepository _empresitmoRepository;
        public EmprestimoRepository(GerenciadorLivroDbContext context, IEmprestimoRepository emprestimoRepository)
        {
            _context = context;
            _empresitmoRepository = emprestimoRepository;
        }

        public async Task<List<Emprestimo>> GetAllAsync()
        {
            return await _context.Emprestimo.ToListAsync();

        }

        public async Task<Emprestimo> GetByIdAsync(int id)
        {
            return await _context.Emprestimo.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task AddAsync(Emprestimo emprestimo)
        {
            await _context.Emprestimo.AddAsync(emprestimo);
            await _context.SaveChangesAsync();

        }

        public void Update(Emprestimo emprestimo)
        {
            _context.Emprestimo.Update(emprestimo);
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<int> RemoveAsync(int id)
        {
            var usuario = await _context.Emprestimo.FirstOrDefaultAsync(x => x.Id == id);
            _context.Remove(usuario);

            await _context.SaveChangesAsync();

            return usuario.Id;
        }

        public async Task<Emprestimo> RealizarEmprestimo(int idLivro, int idUsuario)
        {
            var livro = await _empresitmoRepository.GetByIdAsync(idLivro);

            if (livro is null)
                return null;

            var emprestimoLivro = new Emprestimo(idUsuario, livro.Id);
            await _context.Emprestimo.AddAsync(emprestimoLivro);
            await _context.SaveChangesAsync();

            return emprestimoLivro;
        }
    }
}
