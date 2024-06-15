using GerenciadorLivro.Core.Entites;

namespace GerenciadorLivro.UnitTests.Core.Entities
{
    public class LivroTests
    {
        [Fact]
        public void Eh_Possivel_Desativar_O_Livro()
        {   
            var livro = new Livro("Teste Livro", "Autor Teste", "0123AcDe99", 2022);

            Assert.NotNull(livro);
            Assert.NotNull(livro.Titulo);
            Assert.NotNull(livro.Autor);
            Assert.NotNull(livro.ISBN);
            livro.Desativar();

        }

        [Fact]
        public void Eh_Possivel_Ativar_O_Livro()
        {
            var livro = new Livro("Teste Livro", "Autor Teste", "0123AcDe99", 2022);
            Assert.NotNull(livro);
            Assert.NotNull(livro.Titulo);
            Assert.NotNull(livro.Autor);
            Assert.NotNull(livro.ISBN);
            livro.Ativar();

        }
    }
}
