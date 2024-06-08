namespace GerenciadorLivro.Core.Entites
{
    public class Livro : BaseEntity
    {
        public Livro(string titulo, string autor, string iSBN, int anoPublicacao)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
        }

        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string ISBN { get; private set; }
        public int AnoPublicacao { get; private set; }
        public bool? Ativo { get; private set; }

        public void Desativar()
        {
            Ativo = false;
        }

        public void Ativar()
        {
            Ativo = true;   
        }

        public void Atualizar(string titulo, string autor, string iSBN, int anoPublicacao)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
        }
    }


}
