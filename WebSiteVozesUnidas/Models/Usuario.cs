using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebSiteVozesUnidas.Models
{
    public class Usuario
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

        public Tipo tipo { get; set; }
    }
    public enum Tipo
    {
        PessoaFisica,
        Empresa,
        ADM
    }
    public class PessoaFisica : Usuario
    {
        public string CPF { get; set; }
        public DateOnly Nascimento { get; set; }
        public string? Habilidades { get; set; }
        public string? Objetivos { get; set; }
        public char Jornalista { get; set; }
    }
    public class Empresa : Usuario
    {
        public string CNPJ { get; set; }
        
    }

}
