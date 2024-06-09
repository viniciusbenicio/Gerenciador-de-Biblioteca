using GerenciadorLivro.Core.Entites;
using System;

namespace GerenciadorLivro.Application.ViewModels.EmprestimoViewModels
{
    public class EmprestimoViewModel
    {
        public EmprestimoViewModel()
        {
            
        }
        public EmprestimoViewModel(string usuario, string livro, DateTime dataEmprestimo, DateTime? dataDevolucao, string mensagem)
        {
            Usuario = usuario;
            Livro = livro;
            DataEmprestimo = dataEmprestimo;
            DataDevolucao = dataDevolucao;
            Mensagem = mensagem;
        }

        public string Usuario { get; set; }
        public string Livro { get; set; }  
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public string Mensagem { get; set; }
    }
}
