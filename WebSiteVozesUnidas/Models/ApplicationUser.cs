using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebSiteVozesUnidas.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? Foto { get; set; }
        public string? Sobre { get; set; }
        public string? Portifolio { get; set; }
        public TipoUsuario Tipo { get; set; }
        public List<MidiaSocial> MidiaSocials { get; set; } = new List<MidiaSocial>();
        public string? Estado { get; set; }
        public string? Cidade { get; set; }

        // Propriedades específicas para PessoaFisica
        public string? CPF { get; set; }
        public DateOnly? Nascimento { get; set; }
        public List<string> Habilidades { get; set; } = new List<string>();
        public string? Objetivos { get; set; }
        public bool Jornalista { get; set; }

        // Propriedades específicas para Empresa
        public string? CNPJ { get; set; }
        public string? Ramo { get; set; }
        public int? Funcionarios { get; set; }

        // FK
        public IEnumerable<Noticia>? Noticias { get; set; }
        public IEnumerable<AvaliacaoEspecialista>? AvaliacoesEspecialhistas { get; set; }
        public IEnumerable<Post>? Posts { get; set; }
        public IEnumerable<Comentario>? Comentarios { get; set; }
        public IEnumerable<LikesPost>? LikesPosts { get; set; }
        public IEnumerable<CandidatoVaga>? CandidatoVagas { get; set; }
        public IEnumerable<VagaEmprego>? VagaEmpregos { get; set; }

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
