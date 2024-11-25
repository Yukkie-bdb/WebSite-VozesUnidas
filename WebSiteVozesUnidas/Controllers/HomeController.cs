using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebSiteVozesUnidas.Data;
using WebSiteVozesUnidas.Models;
using WebSiteVozesUnidas.ViewModels;

namespace WebSiteVozesUnidas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _logger = logger;
            _context = context;

        }


        public async Task<IActionResult> Index()
        {
            var especialistasComMedia = _context.Especialistas
        .Select(e => new
        {
            e.IdEspecialista,
            e.ImgEspecialista,
            e.Nome,
            e.Telefone,
            e.Email,
            e.Especialhidade,
            MediaEstrelas = e.AvaliacoesEspecialistas.Any()
                ? e.AvaliacoesEspecialistas.Average(a => a.Estrelas)
                : 0
        })
        .OrderByDescending(e => e.MediaEstrelas)
        .Take(3)  // Limita aos 3 primeiros
        .ToList();

            //ViewBag.especialistasList = await _context.Especialistas.OrderBy().Take(3).ToListAsync();
            ViewBag.especialistasList = especialistasComMedia;

            ViewBag.noticiasList = await _context.Noticias.ToListAsync();


            var materiais = await _context.MaterialDidaticos
     .Include(m => m.Categoria) // Inclui a categoria relacionada
     .ToListAsync(); // Traz os dados para mem�ria

            var materiaisPorCategoria = materiais
                .GroupBy(m => m.Categoria.Categoria) // Agrupa por categoria
                .Take(2) // Limita a 2 categorias
                .ToList();

            var categoriasComMateriais = materiaisPorCategoria
    .Select(group => new CategoriaMaterials
    {
        Categoria = group.Key,
        MaterialDidaticos = group // Limita a 2 materiais por categoria
    })
    .ToList();

            ViewBag.CategoriasComMateriais = categoriasComMateriais;

            ViewBag.empregos = _context.VagaEmpregos.Include(u => u.Usuario).Take(3).ToList();


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult APAGAR()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
