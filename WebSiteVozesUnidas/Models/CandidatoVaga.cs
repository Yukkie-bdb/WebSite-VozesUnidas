namespace WebSiteVozesUnidas.Models
{
    public class CandidatoVaga
    {
        public Guid IdCandidatoVaga { get; set; }
        public Guid Id { get; set; }
        public ApplicationUser? Usuario { get; set; }
        public Guid IdVaga { get; set; }
        public VagaEmprego? VagasEmprego { get; set; }
    }
}
