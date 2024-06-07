using GerenciadorLivro.Core.Entites;
using System.Threading.Tasks;

namespace GerenciadorLivro.Core.Repositories
{
    public interface IUsuarioRepository
    {
        Task AddAsync(Usuario usuario);
    }
}
