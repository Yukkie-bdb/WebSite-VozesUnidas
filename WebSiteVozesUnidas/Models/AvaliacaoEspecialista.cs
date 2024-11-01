using System.ComponentModel.DataAnnotations;

namespace WebSiteVozesUnidas.Models
{
    public class AvaliacaoEspecialista
    {
        public Guid IdAvaliacaoEspecialhis { get; set; }
        public string Descricao { get; set; }
        public int Estrelas { get; set; }
        public Guid UsuarioId { get; set; }
        public ApplicationUser? Usuario { get; set; }
        public Guid EspecialistaId { get; set; }
        public Especialista? Especialistas { get; set; }
    }
}
