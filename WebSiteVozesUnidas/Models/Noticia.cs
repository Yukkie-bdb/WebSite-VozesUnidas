namespace WebSiteVozesUnidas.Models
{
    public class Noticia
    {
        public Guid IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Imagem { get; set; }
        public string Resumo { get; set; }
        public string Conteudo { get; set; }
        DateTime Publicacao { get; set; }
        public Guid IdUsuario { get; set; }
        public ApplicationUser? Usuario { get; set; }
    }
}
