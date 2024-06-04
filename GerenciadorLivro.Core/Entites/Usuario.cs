namespace GerenciadorLivro.Core.Entites
{
    public class Usuario : BaseEntity
    {
        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
    }
}
