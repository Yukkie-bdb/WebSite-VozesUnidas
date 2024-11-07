using System.ComponentModel.DataAnnotations;

namespace WebSiteVozesUnidas.Models
{
    public class AvaliacaoEspecialista
    {
        public Guid IdAvaliacaoEspecialhis { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public int Estrelas { get; set; }
        [Display(Name = "Usuário")]
        public Guid UsuarioId { get; set; }
        public ApplicationUser? Usuario { get; set; }
        [Display(Name = "Especialista")]
        public Guid EspecialistaId { get; set; }
        public Especialista? Especialistas { get; set; }
    }
}
