using GerenciadorLivro.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciadorLivro.Infrastructure.Persistence.Configurations
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(l => l.Id);
        }
    }
}
