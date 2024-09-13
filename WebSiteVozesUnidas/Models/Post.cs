using Microsoft.AspNetCore.Identity;

namespace WebSiteVozesUnidas.Models
{
    public class Post
    {
        public Guid IdPost { get; set; }
        public string Titulo { get; set; }
        public string SubTituloResumo { get; set; }
        public string Conteudo { get; set; }
        public string Imagem { get; set; }
        public DateTime Publicacao { get; set; }
        public Guid? IdUsuario { get; set; }
        public ApplicationUser? Usuario { get; set; }
        public Guid? IdCategoria { get; set; }
        public CategoriaPost? CategoriaPost { get; set; }
        public IEnumerable<Comentario>? Comentarios { get; set; }
        public IEnumerable<LikesPost>? Likes { get; set; }

    }
}
