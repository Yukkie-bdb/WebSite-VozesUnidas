﻿namespace WebSiteVozesUnidas.Models
{
    public class AvaliacaoEspecialista
    {
        public Guid IdAvaliacaoEspecialista { get; set; }
        public decimal Avaliacao { get; set; }
        public string Descricao { get; set; }
        public Guid IdUsuario { get; set; }
        public ApplicationUser? Usuario { get; set; }
    }
}
