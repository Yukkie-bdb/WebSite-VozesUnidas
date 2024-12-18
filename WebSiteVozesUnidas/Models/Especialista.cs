﻿using System.ComponentModel.DataAnnotations;

namespace WebSiteVozesUnidas.Models
{
    public class Especialista
    {
        public Guid IdEspecialista { get; set; }
        [Display(Name = "Imagem")]
        public string? ImgEspecialista { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        [Display(Name = "Especialidade")]
        public string Especialhidade { get; set; }
        public IEnumerable<AvaliacaoEspecialista>? AvaliacoesEspecialistas { get; set; }

    }
}
