namespace WebSiteVozesUnidas.Models
{
    public class CategoriaPost
    {
        public Guid IdCategoriaPost { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Post>? Posts { get; set; }

    }
}
