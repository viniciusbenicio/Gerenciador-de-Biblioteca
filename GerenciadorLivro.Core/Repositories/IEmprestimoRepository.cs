using GerenciadorLivro.Core.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorLivro.Core.Repositories
{
    public interface IEmprestimoRepository
    {
        Task<List<Emprestimo>> GetAllAsync();
        Task<Emprestimo> GetByIdAsync(int id);
        Task AddAsync(Emprestimo emprestimo);
        void Update(Emprestimo emprestimo);
        Task SaveChangesAsync();
        Task<int> RemoveAsync(int id);
        Task<Emprestimo> RealizarEmprestimo(int idLivro, int idUsuario, int prazoDias);
        int CalcularPrazoEmprestimo(Emprestimo emprestimo);
    }
}
