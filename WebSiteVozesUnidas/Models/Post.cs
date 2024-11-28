using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebSiteVozesUnidas.Models
{
    public class Post
    {
        public Guid IdPost { get; set; }
        public string Titulo { get; set; }
        public string SubTituloResumo => ResumirTexto(Conteudo, 500);

        public string Conteudo { get; set; }
        public string? Imagem { get; set; }
        public DateTime Publicacao { get; set; }
        public Guid? Id { get; set; }
        public ApplicationUser? Usuario { get; set; }
        public Guid? IdCategoria { get; set; }
        public CategoriaPost? CategoriaPost { get; set; }
        public IEnumerable<Comentario>? Comentarios { get; set; }
        public IEnumerable<LikesPost>? Likes { get; set; }
        private string ResumirTexto(string texto, int limiteCaracteres)
        {
            if (string.IsNullOrEmpty(texto))
                return string.Empty;

            if (texto.Length <= limiteCaracteres)
                return texto;

            string resumo = texto.Substring(0, limiteCaracteres);

            int ultimoEspaco = resumo.LastIndexOf(' ');
            if (ultimoEspaco > 0)
                resumo = resumo.Substring(0, ultimoEspaco);

            return resumo + "...";
        }
    }
    public class LikesPost
    {
        public Guid IdLikesPost { get; set; }
        public Guid? IdPost { get; set; }

        [ForeignKey(nameof(IdPost))]
        public Post? Post { get; set; }
        public Guid? Id { get; set; }

        [ForeignKey(nameof(Id))]
        public ApplicationUser? Usuario { get; set; }
    }
}
