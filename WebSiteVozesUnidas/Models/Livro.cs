namespace WebSiteVozesUnidas.Models
{
    public class Livro
    {
        public Guid IdLivro { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Resumo { get; set; }
        public string PDF { get; set; }
        public string Capa { get; set; }
    }
}
