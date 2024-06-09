using GerenciadorLivro.Core.Entites;
using System;

namespace GerenciadorLivro.Application.ViewModels
{
    public class EmprestimoViewModel
    {
        public EmprestimoViewModel()
        {
            
        }
        public EmprestimoViewModel(int idUsuario, Usuario usuario, int idLivro, Livro livro, DateTime dataEmprestimo)
        {
            IdUsuario = idUsuario;
            Usuario = usuario;
            IdLivro = idLivro;
            Livro = livro;
            DataEmprestimo = dataEmprestimo;
        }

        public int IdUsuario { get;  set; }
        public Usuario Usuario { get; set; }
        public int IdLivro { get;  set; }
        public Livro Livro { get;  set; }
        public DateTime DataEmprestimo { get;  set; }
    }
}
