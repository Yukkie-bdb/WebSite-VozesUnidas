using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebSiteVozesUnidas.Models
{
    public class ApplicationUser : IdentityUser
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string?	Foto { get; set; }
        public string?	Sobre { get; set; }
        public string?	Facebook { get; set; }
        public string?	Instagram { get; set; }
        public string?	Twitter { get; set; }
        public Tipo Tipo { get; set; }
        public IEnumerable<Noticia>? Noticias { get; set; }
        public IEnumerable<AvaliacaoEspecialista>? AvaliacoesEspecialhistas { get; set; }
        public IEnumerable<Post>? Posts { get; set; }
        public IEnumerable<Comentario>? Comentarios { get; set; }
        public IEnumerable<LikesPost>? Likes { get; set; }

    }
    public enum Tipo
    {
        PessoaFisica,
        Empresa,
        ADM
    }
    public class PessoaFisica : ApplicationUser
    {
        public string CPF { get; set; }
        public DateOnly Nascimento { get; set; }
        public string? Habilidades { get; set; }
        public string? Objetivos { get; set; }
        public char Jornalista { get; set; }
        public IEnumerable<CandidatoVaga>? Vagas { get; set; }

    }
    public class Empresa : ApplicationUser
    {
        public string CNPJ { get; set; }
        public IEnumerable<VagaEmprego>? Vagas { get; set; }


    }

}
