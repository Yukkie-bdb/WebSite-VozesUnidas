﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WebSiteVozesUnidas.Models
{
    public class Comentario
    {
        public Guid IdComentario { get; set; }
        public DateTime Publicacao { get; set; }
        public string comentario { get; set; }
        public Guid? IdPost { get; set; }

        [ForeignKey(nameof(IdPost))]
        public Post? Post { get; set; }
        public Guid? Id { get; set; }

        [ForeignKey(nameof(Id))]
        public ApplicationUser? Usuario { get; set; }

        public IEnumerable<LikeComen>? LikeComens { get; set; }
    }
    public class LikeComen
    {
        public Guid IdLikeComen { get; set; }
        public Guid? IdComentario { get; set; }

        [ForeignKey(nameof(IdComentario))]
        public Comentario? Comentario { get; set; }
        public Guid? Id { get; set; }

        [ForeignKey(nameof(Id))]
        public ApplicationUser? Usuario { get; set; }
    }
}
