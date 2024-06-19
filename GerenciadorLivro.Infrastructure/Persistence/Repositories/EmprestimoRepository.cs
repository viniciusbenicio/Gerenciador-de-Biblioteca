using GerenciadorLivro.Core.Entites;
using GerenciadorLivro.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<List<Emprestimo>> GetAllAsync()
        {
            return await _context.Emprestimo.Include(x => x.Usuario).Include(x => x.Livro).ToListAsync();

        }

        public async Task<Emprestimo> GetByIdAsync(int id)
        {
            return await _context.Emprestimo.Include(x => x.Usuario).Include(x => x.Livro).FirstOrDefaultAsync(x => x.Id == id);

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

        public async Task<Emprestimo> RealizarEmprestimo(int idLivro, int idUsuario, int prazoDias)
        {
            var livro = await _livroRepository.GetByIdAsync(idLivro);

            if (livro is null)
                return null;

            var emprestimoLivro = new Emprestimo(idUsuario, livro.Id);

            if (prazoDias == 0)
            {
                return null;
            }

            var dataDevolucao = emprestimoLivro.DataEmprestimo.AddDays(prazoDias);
            emprestimoLivro.AtualizarDataDevolucao(dataDevolucao);

            await _context.Emprestimo.AddAsync(emprestimoLivro);
            

            return emprestimoLivro;
        }

        public int CalcularPrazoEmprestimo(Emprestimo emprestimo)
        {
            var DataAtual = DateTime.Now;
            int diasDeAtraso = 0;

            if (DataAtual > emprestimo.DataDevolucao)
            {
                TimeSpan diferenca = DataAtual - emprestimo.DataDevolucao.GetValueOrDefault();
                diasDeAtraso = Math.Abs(diferenca.Days);
            }

            return diasDeAtraso;
        }
    }
}
