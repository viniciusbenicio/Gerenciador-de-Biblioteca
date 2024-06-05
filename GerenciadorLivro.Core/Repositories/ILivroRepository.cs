using GerenciadorLivro.Core.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorLivro.Core.Repositories
{
    public interface ILivroRepository
    {
        Task<List<Livro>> GetAllAsync();
        Task<Livro> GetByIdAsync(int id);
        Task AddAsync(Livro livro);
        Task SaveChangesAsync();
        Task RemoveAsync(int id);
    }
}
