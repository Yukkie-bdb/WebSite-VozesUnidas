﻿namespace WebSiteVozesUnidas.Models
{
    public class VagaEmprego
    {
        Guid IdVaga {  get; set; }
        public string Cargo { get; set; }
        public string ResumoVaga { get; set; }
        public string Foto { get; set; }
        public string HorarioExpediente { get; set; }
        public string Beneficios { get; set; }
        public string Requisitos { get; set; }
        public string DescricaoVaga { get; set; }
        public Guid? IdEmpresa { get; set; }
        public ApplicationUser? Usuario { get; set; }
        public IEnumerable<CandidatoVaga>? Vagas { get; set; }

    }
}
