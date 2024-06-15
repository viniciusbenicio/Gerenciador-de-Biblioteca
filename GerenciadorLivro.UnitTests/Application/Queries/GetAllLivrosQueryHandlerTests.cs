using GerenciadorLivro.Application.Queries.LivroQueries.GetAllLivros;
using GerenciadorLivro.Core.Entites;
using GerenciadorLivro.Core.Repositories;
using Moq;

namespace GerenciadorLivro.UnitTests.Application.Queries
{
    public class GetAllLivrosQueryHandlerTests
    {
        [Fact]
        public async Task Deve_Retornar_Todos_Os_Livros()
        {
            var livros = new List<Livro>
            {
                new Livro ("Livro 1", "Autor 1", "Isbn 1", 2020),
                new Livro ("Livro 2", "Autor 2", "Isbn 2", 2021),
                new Livro ("Livro 3", "Autor 3", "Isbn 3", 2022),
                new Livro ("Livro 4", "Autor 4", "Isbn 4", 2023),
                new Livro ("Livro 5", "Autor 5", "Isbn 5", 2024),
            };

            var livroRepositoryMock = new Mock<ILivroRepository>();

            livroRepositoryMock.Setup(l => l.GetAllAsync().Result).Returns(livros);

            var getallLivros = new GetAllLivrosQuery("");
            var getAllLivrosQueryHandler = new GetAllLivrosQueryHandler(livroRepositoryMock.Object);

            var livroViewModels = await getAllLivrosQueryHandler.Handle(getallLivros, new CancellationToken());

            Assert.NotNull(livroViewModels);
            Assert.NotEmpty(livroViewModels);
            Assert.Equal(livroViewModels.Count, livroViewModels.Count);

            livroRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);

        }
    }
}
