using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using WebSiteVozesUnidas.Data;
using WebSiteVozesUnidas.Models;

namespace WebSiteVozesUnidas.Controllers
{

    [Authorize(Roles = "ADM")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CriarNoticia(int itens)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var noticias = new List<Noticia>();
            var imagensDisponiveis = new[] { "noticia1.jpg", "noticia2.jpg", "noticia3.jpg", "noticia4.jpg", "noticia5.jpg" };
            var random = new Random();

            using (var client = new HttpClient())
            {
                for (int i = 0; i < itens; i++)
                {
                    // Chamada para a API de Lorem Ipsum
                    var response = await client.GetStringAsync("https://loripsum.net/api/7/short/headers");

                    noticias.Add(new Noticia
                    {
                        IdNoticia = Guid.NewGuid(),
                        Titulo = $"Título da Notícia {i + 1}",
                        SubTitulo = $"Subtítulo da Notícia {i + 1}",
                        Imagem = imagensDisponiveis[random.Next(imagensDisponiveis.Length)], // Seleção aleatória da imagem
                        Conteudo = response, // Conteúdo obtido da API
                        Publicacao = DateTime.Now,
                        Id = userId,
                        Usuario = null // Substituir por um usuário real, se necessário
                    });
                }
            }

            // Salvar as notícias no banco de dados (exemplo com Entity Framework)
            _context.Noticias.AddRange(noticias);
            _context.SaveChanges();

            return RedirectToAction("Index", "Noticias");
        }

        public IActionResult CriarEspecialista(int itens)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var especialistas = new List<Especialista>();
            var imagensDisponiveis = new[] { "especialista1.jpg", "especialista2.jpg", "especialista3.jpg", "especialista4.jpg", "especialista5.jpg" };
            var random = new Random();

            using (var client = new HttpClient())
            {
                for (int i = 0; i < itens; i++)
                {
                    // Gerar nome, telefone e email fictícios (opcionalmente usando APIs ou lógica customizada)
                    var nome = $"Especialista {i + 1}";
                    var telefone = $"(11) 9{random.Next(1000, 9999)}-{random.Next(1000, 9999)}";
                    var email = $"especialista{i + 1}@exemplo.com";
                    var especialidade = $"Especialidade {i + 1}";

                    especialistas.Add(new Especialista
                    {
                        IdEspecialista = Guid.NewGuid(),
                        ImgEspecialista = imagensDisponiveis[random.Next(imagensDisponiveis.Length)], // Seleção aleatória da imagem
                        Nome = nome,
                        Telefone = telefone,
                        Email = email,
                        Especialhidade = especialidade,
                        AvaliacoesEspecialistas = null // Pode ser configurado conforme o contexto do projeto
                    });
                }
            }

            // Salvar os especialistas no banco de dados (exemplo com Entity Framework)
            _context.Especialistas.AddRange(especialistas);
            _context.SaveChanges();

            return RedirectToAction("Index", "Especialista");
        }

        public async Task<IActionResult> CriarMaterial(int itens)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var materiaisDidaticos = new List<MaterialDidatico>();
            var categorias = _context.CategoriaMaterials.Select(u => u.IdCategoriaMaterial).ToList();
            var imagensDisponiveis = new[] { "material1.jpg", "material2.jpg", "material3.jpg", "material4.jpg", "material5.jpg" };
            var random = new Random();

            using (var client = new HttpClient())
            {
                for (int i = 0; i < itens; i++)
                {
                    // Chamada para a API de Lorem Ipsum
                    var descricao = await client.GetStringAsync("https://loripsum.net/api/5/short/headers");

                    materiaisDidaticos.Add(new MaterialDidatico
                    {
                        IdMaterialDidatico = Guid.NewGuid(),
                        Titulo = $"Material Didático {i + 1}",
                        Descricao = descricao, // Conteúdo obtido da API
                        ImgMaterial = imagensDisponiveis[random.Next(imagensDisponiveis.Length)], // Seleção aleatória da imagem
                        LinkYoutube = $"https://www.youtube.com/watch?v={Guid.NewGuid()}", // Link fictício para o YouTube
                        CategoriaId = categorias[random.Next(categorias.Count)], // Seleção aleatória de CategoriaId do banco
                        Categoria = null // Substituir por uma categoria real, se necessário
                    });
                }
            }

            // Salvar os materiais didáticos no banco de dados (exemplo com Entity Framework)
            _context.MaterialDidaticos.AddRange(materiaisDidaticos);
            _context.SaveChanges();

            return RedirectToAction("Index", "MaterialDidatico");
        }

        public async Task<IActionResult> CriarVaga(int itens)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var vagasEmprego = new List<VagaEmprego>();
            var estadosDisponiveis = new[] { "São Paulo", "Rio de Janeiro", "Minas Gerais", "Bahia", "Paraná" };
            var cidadesDisponiveis = new[] { "São Paulo", "Rio de Janeiro", "Belo Horizonte", "Salvador", "Curitiba" };
            var cargosDisponiveis = new[] { "Desenvolvedor", "Analista de Sistemas", "Gerente de TI", "Designer", "Assistente Administrativo" };
            var horariosDisponiveis = new[] { "09:00 às 18:00", "08:00 às 17:00", "14:00 às 23:00", "10:00 às 19:00" };
            var beneficiosDisponiveis = new[] { "Vale Alimentação", "Vale Transporte", "Plano de Saúde", "Bonificação", "Assistência Médica" };
            var requisitosDisponiveis = new[] { "Experiência em desenvolvimento", "Conhecimento em gerenciamento de projetos", "Conhecimento avançado em Excel", "Inglês fluente", "Curso de Design Gráfico" };
            var regimeContratacaoDisponivel = new[] { "CLT", "PJ", "Estágio", "Freelancer" };
            var random = new Random();

            using (var client = new HttpClient())
            {
                for (int i = 0; i < itens; i++)
                {
                    // Gerando uma descrição aleatória
                    var descricaoVaga = await client.GetStringAsync("https://loripsum.net/api/7/short/headers");

                    vagasEmprego.Add(new VagaEmprego
                    {
                        IdVagaEmprego = Guid.NewGuid(),
                        Cargo = cargosDisponiveis[random.Next(cargosDisponiveis.Length)], // Seleção aleatória de cargo
                        NumeroVagas = random.Next(1, 10), // Número aleatório de vagas
                        HorarioExpediente = horariosDisponiveis[random.Next(horariosDisponiveis.Length)], // Seleção aleatória de horário
                        Beneficios = beneficiosDisponiveis[random.Next(beneficiosDisponiveis.Length)], // Seleção aleatória de benefício
                        Requisitos = requisitosDisponiveis[random.Next(requisitosDisponiveis.Length)], // Seleção aleatória de requisito
                        RegimeContratacao = regimeContratacaoDisponivel[random.Next(regimeContratacaoDisponivel.Length)], // Seleção aleatória de regime de contratação
                        DescricaoVaga = descricaoVaga, // Descrição da vaga vinda da API de Lorem Ipsum
                        Salario = random.Next(2000, 10000), // Salário aleatório
                        LocalTrabalho = cidadesDisponiveis[random.Next(cidadesDisponiveis.Length)], // Seleção aleatória de cidade
                        Estado = estadosDisponiveis[random.Next(estadosDisponiveis.Length)], // Seleção aleatória de estado
                        Cidade = cidadesDisponiveis[random.Next(cidadesDisponiveis.Length)], // Seleção aleatória de cidade
                        Publicacao = DateTime.Now, // Data atual da publicação
                        UsuarioId = userId, // Usuário logado
                        Usuario = null, // Associar a um usuário real se necessário
                        Vagas = null // Associar a candidatos reais, se necessário
                    });
                }
            }

            // Salvar as vagas de emprego no banco de dados (exemplo com Entity Framework)
            _context.VagaEmpregos.AddRange(vagasEmprego);
            _context.SaveChanges();
            return RedirectToAction("Index", "VagaEmpregos");
        }

        public async Task<IActionResult> CriarForum(int itens)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var posts = new List<Post>();
            var imagensDisponiveis = new[] { "forum1.jpg", "forum2.jpg", "forum3.jpg", "forum4.jpg", "forum5.jpg" };
            var categoriasDisponiveis = _context.CategoriaPosts.Select(c => c.IdCategoriaPost).ToList();
            if (categoriasDisponiveis.Count == 0)
            {
                // Trate o caso em que não há categorias
                // Você pode retornar um erro, ou criar uma categoria padrão, por exemplo.
                return BadRequest("Não há categorias disponíveis.");
            }
                var random = new Random();

            using (var client = new HttpClient())
            {
                for (int i = 0; i < itens; i++)
                {
                    // Chamada para a API de Lorem Ipsum
                    var conteudoPost = await client.GetStringAsync("https://loripsum.net/api/7/short/headers");

                    posts.Add(new Post
                    {
                        IdPost = Guid.NewGuid(),
                        Titulo = $"Post do Fórum {i + 1}",
                        Conteudo = conteudoPost, // Conteúdo completo do post
                        Imagem = imagensDisponiveis[random.Next(imagensDisponiveis.Length)], // Seleção aleatória da imagem
                        Publicacao = DateTime.Now, // Data atual da publicação
                        Id = userId, // Associar ao usuário logado
                        Usuario = null, // Substituir com o usuário real, se necessário
                        IdCategoria = categoriasDisponiveis[random.Next(categoriasDisponiveis.Count)], // Seleção aleatória de categoria
                        CategoriaPost = null, // Associar a categoria real, se necessário
                        Comentarios = null, // Associar comentários reais, se necessário
                        Likes = null // Associar likes reais, se necessário
                    });
                }
            }

            // Salvar os posts do fórum no banco de dados (exemplo com Entity Framework)
            _context.Posts.AddRange(posts);
            _context.SaveChanges();
            return RedirectToAction("Index", "Posts");
        }
    }
}
