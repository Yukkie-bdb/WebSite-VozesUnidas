using Microsoft.EntityFrameworkCore;

namespace WebSiteVozesUnidas.Models
{
    public class Noticia
    {
        public Guid IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string? Imagem { get; set; }
        public string Resumo => ResumirTexto(Conteudo, 540);
        
        public string Conteudo { get; set; }
        public DateTime Publicacao { get; set; }
        public Guid Id { get; set; }
        public ApplicationUser? Usuario { get; set; }

        private string ResumirTexto(string texto, int limiteCaracteres)
        {
            if(string.IsNullOrEmpty(texto))
            return string.Empty;

            if (texto.Length <= limiteCaracteres)
                return texto;

            string resumo = texto.Substring(0, limiteCaracteres);

            int ultimoEspaco = resumo.LastIndexOf(' ');
            if (ultimoEspaco > 0)
                resumo = resumo.Substring(0, ultimoEspaco);

            return resumo + "...";
        }


    }
}
