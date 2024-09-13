namespace WebSiteVozesUnidas.Models
{
    public class Comentario
    {
        public Guid IdComentario { get; set; }
        public DateTime Publicacao { get; set; }
        public string comentario {  get; set; }
        public Guid? IdPost { get; set; }
        public Post? Post { get; set; }
        public Guid? IdUsuario { get; set; }
        public ApplicationUser? Usuario { get; set; }
    }
}
