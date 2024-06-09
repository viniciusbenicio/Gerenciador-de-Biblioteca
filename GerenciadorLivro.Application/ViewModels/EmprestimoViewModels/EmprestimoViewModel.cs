using GerenciadorLivro.Core.Entites;
using System;

namespace GerenciadorLivro.Application.ViewModels.EmprestimoViewModels
{
    public class EmprestimoViewModel
    {
        
        public EmprestimoViewModel(int usuarioId, string nome, int idLivro, string titulo, DateTime dataEmprestimo)
        {
            UsuarioId = usuarioId;
            Nome = nome;
            IdLivro = idLivro;
            Titulo = titulo;
            DataEmprestimo = dataEmprestimo;
        }

        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public int IdLivro { get; set; }
        public string Titulo { get; set; }  
        public DateTime DataEmprestimo { get; set; }
    }
}
