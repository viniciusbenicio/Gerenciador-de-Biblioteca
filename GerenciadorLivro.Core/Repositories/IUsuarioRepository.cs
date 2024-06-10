using GerenciadorLivro.Core.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorLivro.Core.Repositories
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario> GetByIdAsync(int id);
        Task AddAsync(Usuario usuario);
        void Update(Usuario usuario);
        Task SaveChangesAsync();
        Task<int> RemoveAsync(int id);
        Task<Usuario> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    }
}
