﻿namespace WebSiteVozesUnidas.Models
{
    public class LikesPost
    {
        public Guid IdLike {  get; set; }


        public Guid? IdPost { get; set; }
        public Post? Post { get; set; }
        public Guid? IdUsuario { get; set; }
        public ApplicationUser? Usuario { get; set; }
    }
}
