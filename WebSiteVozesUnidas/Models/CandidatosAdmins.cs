namespace WebSiteVozesUnidas.Models
{
    public class CandidatosAdmins
    {
        public Guid IdCandidatosAdmins { get; set; }
        public string? Motivo {  get; set; }
        public Guid UsuarioId { get; set; }
        public ApplicationUser? Usuario { get; set; }
    }
}
