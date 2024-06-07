using GerenciadorLivro.Core.Entites;
using System.Threading.Tasks;

namespace GerenciadorLivro.Core.Repositories
{
    public interface IEmprestimoRepository
    {
        Task<Emprestimo> RealizarEmprestimo(int idLivro, int idUsuario);
    }
}
