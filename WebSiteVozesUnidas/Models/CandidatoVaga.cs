namespace WebSiteVozesUnidas.Models
{
    public class CandidatoVaga
    {
        public Guid IdCandidatura {  get; set; }
        public Guid? IdUsuario { get; set; }
        public ApplicationUser? Usuario { get; set; }
        public Guid? IdVaga { get; set; }
        public VagaEmprego? VagasEmprego
        {
            get; set;
        }
     }
}
