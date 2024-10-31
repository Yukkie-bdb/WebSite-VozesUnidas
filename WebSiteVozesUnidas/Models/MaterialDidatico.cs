using System.ComponentModel.DataAnnotations;

namespace WebSiteVozesUnidas.Models
{
    public class MaterialDidatico
    {
        public Guid IdMaterialDidatico { get; set; }
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Categoria")]
        public Guid CategoriaId { get; set; }
        public CategoriaMaterials? Categoria { get; set; }
        [Display(Name = "Imagem")]
        public string? ImgMaterial { get; set; }
        [Display(Name = "Link Youtube")]
        public string LinkYoutube { get; set; }
    } 
}
