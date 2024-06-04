using GerenciadorLivro.Core.Entites;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GerenciadorLivro.Infrastructure
{
    public class GerenciadorLivroDbContext : DbContext
    {
        public GerenciadorLivroDbContext(DbContextOptions<GerenciadorLivroDbContext> options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Emprestimo> Emprestimo { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
