namespace GerenciadorLivro.Application.ViewModels.UsuarioViewModel
{
    public class LoginUsuarioViewModel
    {
        public LoginUsuarioViewModel(string email, string token)
        {
            Email = email;
            Token = token;
        }

        public string Email { get; private set; }
        public string Token { get; private set; }
    }
}
