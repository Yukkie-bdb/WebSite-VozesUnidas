using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebSiteVozesUnidas.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Foto { get; set; }
        public string? Sobre { get; set; }
        public TipoUsuario Tipo { get; set; }
        public List<MidiaSocial> MidiaSocials { get; set; } = new List<MidiaSocial>();

        // Propriedades específicas para PessoaFisica
        public string? CPF { get; set; }
        public DateOnly? Nascimento { get; set; }
        public string[]? Habilidades { get; set; }
        public string? Objetivos { get; set; }
        public bool? Jornalista { get; set; }

        // Propriedades específicas para Empresa
        public string? CNPJ { get; set; }
    }
    public enum TipoUsuario
    {
        PessoaFisica,
        Empresa,
        ADM
    }
    public class MidiaSocial
    {
        public int IdMidiaSocial { get; set; }
        public string Plataforma { get; set; } // Nome da rede social (ex: Twitter, Instagram)
        public string Url { get; set; } // URL da conta
    }
}
