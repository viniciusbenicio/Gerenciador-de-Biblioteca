namespace GerenciadorLivro.Application.ViewModels
{
    public class LivroViewModel
    {
        public LivroViewModel(string titulo, string autor, string iSBN, int anoPublicacao, bool? ativo)
        {
            Titulo = titulo;
            Autor = autor;
            ISBN = iSBN;
            AnoPublicacao = anoPublicacao;
            Ativo = ativo;
        }

        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int AnoPublicacao { get; set; }
        public bool? Ativo { get; set; }
    }
}
