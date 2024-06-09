using System;

namespace GerenciadorLivro.Core.Entites
{
    public class Emprestimo : BaseEntity
    {
        public Emprestimo(int idUsuario, int idLivro)
        {
            IdUsuario = idUsuario;
            IdLivro = idLivro;
            DataEmprestimo = DateTime.Now;
        }

        public int IdUsuario { get; private set; }
        public Usuario Usuario { get; set; }
        public int IdLivro { get; private set; }
        public Livro Livro { get; private set; }
        public DateTime DataEmprestimo { get; private set; }

        public void Atualizar(int idLivro, DateTime dataEmprestimo)
        {
            IdLivro = idLivro;
            DataEmprestimo = dataEmprestimo;
        }
    }
}
