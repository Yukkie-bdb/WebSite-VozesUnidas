using WebSiteVozesUnidas.Models;

namespace WebSiteVozesUnidas.ViewModels
{
    public class UserDebugViewModel
    {
        // Campos padrão do Identity
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; }

        // Campos personalizados de ApplicationUser
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

        // Relacionamentos (FKs)
        public IEnumerable<Noticia>? Noticias { get; set; }
        public IEnumerable<AvaliacaoEspecialista>? AvaliacoesEspecialista { get; set; }
        public IEnumerable<Post>? Posts { get; set; }
        public IEnumerable<Comentario>? Comentarios { get; set; }
        public IEnumerable<LikesPost>? LikesPosts { get; set; }
        public IEnumerable<CandidatoVaga>? CandidatoVagas { get; set; }
        public IEnumerable<VagaEmprego>? VagaEmpregos { get; set; }
        public IEnumerable<CandidatosJornalistas>? CandidatosJornalistass { get; set; }
    }
}
