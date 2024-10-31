namespace WebSiteVozesUnidas.Models
{
    public class CandidatosJornalistas
    {
        public Guid IdCandidatosJornalistas { get; set; }
        public string? Motivo {  get; set; }
        public Guid UsuarioId { get; set; }
        public ApplicationUser? Usuario { get; set; }
    }
}
