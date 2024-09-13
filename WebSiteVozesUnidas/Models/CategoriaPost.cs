namespace WebSiteVozesUnidas.Models
{
    public class CategoriaPost
    {
        public Guid IdCategoria { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Post>? Posts { get; set; }

    }
}
