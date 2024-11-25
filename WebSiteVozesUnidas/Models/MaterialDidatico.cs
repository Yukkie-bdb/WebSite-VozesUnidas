using System.ComponentModel.DataAnnotations;

namespace WebSiteVozesUnidas.Models
{
    public class MaterialDidatico
    {
        public Guid IdMaterialDidatico { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string? ImgMaterial { get; set; }
        public string? LinkYoutube { get; set; }
        public Guid CategoriaId { get; set; }
        public CategoriaMaterials? Categoria { get; set; }
    } 
}
