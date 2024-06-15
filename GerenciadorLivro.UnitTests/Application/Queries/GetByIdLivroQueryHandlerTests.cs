using GerenciadorLivro.Application.Queries.LivroQueries.GetByIdLivro;
using GerenciadorLivro.Core.Entites;
using GerenciadorLivro.Core.Repositories;
using Moq;

namespace GerenciadorLivro.UnitTests.Application.Queries
{
    public class GetByIdLivroQueryHandlerTests
    {
        [Fact]
        public async Task Deve_Retornar_Todos_Os_Livros()
        {
            var livro = new Livro("","","",0);
            var getLivroById = new GetByIdLivroQuery(1);

            var livroRepositoryMock = new Mock<ILivroRepository>();

            livroRepositoryMock.Setup(l => l.GetByIdAsync(1).Result).Returns(livro);

            var getByIdLivrosQueryHandler = new GetByIdLivroQueryHandler(livroRepositoryMock.Object);

            var livroViewModels = await getByIdLivrosQueryHandler.Handle(getLivroById, new CancellationToken());

            Assert.NotNull(livroViewModels);

             livroRepositoryMock.Verify(pr => pr.GetByIdAsync(1).Result, Times.Once);

        }
    }
}
