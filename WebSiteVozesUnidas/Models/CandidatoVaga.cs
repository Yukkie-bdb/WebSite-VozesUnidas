using System.ComponentModel.DataAnnotations.Schema;

namespace WebSiteVozesUnidas.Models
{
    public class CandidatoVaga
    {
        public Guid IdCandidatoVaga { get; set; }

        // FK para o usuário
        public Guid UsuarioId { get; set; }

        [ForeignKey(nameof(UsuarioId))]
        public ApplicationUser? Usuario { get; set; }

        // FK para a vaga
        public Guid VagaEmpregoId { get; set; }

        [ForeignKey(nameof(VagaEmpregoId))]
        public VagaEmprego? VagaEmprego { get; set; }
    }
}
