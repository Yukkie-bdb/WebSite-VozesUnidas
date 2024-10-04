namespace WebSiteVozesUnidas.Models
{
    public class VagaEmprego
    {
        public Guid IdVagaEmprego { get; set; }
        public string Cargo { get; set; }
        public int NumeroVagas { get; set; }
        public string HorarioExpediente { get; set; }
        public string Beneficios { get; set; }
        public string Requisitos { get; set; }
        public string RegimeContratacao { get; set; }
        public string DescricaoVaga { get; set; }
        public decimal Salario { get; set; }
        public string LocalTrabalho { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public DateTime Publicacao { get; set; }
        public Guid UsuarioId { get; set; }
        public ApplicationUser? Usuario { get; set; }
        public IEnumerable<CandidatoVaga>? Vagas { get; set; }

    }
}
