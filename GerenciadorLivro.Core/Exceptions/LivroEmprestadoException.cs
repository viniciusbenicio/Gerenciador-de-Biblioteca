using System;

namespace GerenciadorLivro.Core.Exceptions
{
    public class LivroEmprestadoException : Exception
    {
        public LivroEmprestadoException() : base("Livro já está emprestado, tente outro.") { }
            
    }
}
