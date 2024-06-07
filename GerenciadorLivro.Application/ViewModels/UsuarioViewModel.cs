﻿namespace GerenciadorLivro.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
