using System;

namespace GerenciadorLivro.Core.Entites
{
    public class Emprestimo : BaseEntity
    {
        public Emprestimo(int usuarioId, int livroId)
        {
            UsuarioId = usuarioId;
            LivroId = livroId;
            DataEmprestimo = DateTime.Now;
        }

        public int UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }
        public int LivroId { get; private set; }
        public Livro Livro { get; private set; }
        public DateTime DataEmprestimo { get; private set; }

        public void Atualizar(int livroId, DateTime dataEmprestimo)
        {
            LivroId = livroId;
            DataEmprestimo = dataEmprestimo;
        }
    }
}
