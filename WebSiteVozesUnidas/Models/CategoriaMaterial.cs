namespace WebSiteVozesUnidas.Models
{
    public class CategoriaMaterials
    {
        public Guid IdCategoriaMaterial { get; set; }
        public string Categoria {  get; set; }
        public IEnumerable<MaterialDidatico>? MaterialDidaticos { get; set; }
    }
}
