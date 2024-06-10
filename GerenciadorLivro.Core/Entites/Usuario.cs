namespace GerenciadorLivro.Core.Entites
{
    public class Usuario : BaseEntity
    {
        public Usuario(string nome, string email, string senha, string role)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            Role = role;
            Ativo = true;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Role { get; private set; }
        public bool Ativo { get; private set; }

        public void Atualizar (string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
    }
}
