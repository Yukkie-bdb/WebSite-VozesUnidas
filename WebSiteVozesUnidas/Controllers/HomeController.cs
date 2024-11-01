using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebSiteVozesUnidas.Models;
using WebSiteVozesUnidas.ViewModels;

namespace WebSiteVozesUnidas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(UserManager<ApplicationUser> userManager, ILogger<HomeController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Index", "Noticias");
            }

            var model = new UserDebugViewModel
            {
                // Campos padrão do Identity
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                EmailConfirmed = user.EmailConfirmed,

                // Campos personalizados de ApplicationUser
                Foto = user.Foto,
                Sobre = user.Sobre,
                Portifolio = user.Portifolio,
                Tipo = user.Tipo,
                MidiaSocials = user.MidiaSocials,
                Estado = user.Estado,
                Cidade = user.Cidade,
                CPF = user.CPF,
                Nascimento = user.Nascimento,
                Habilidades = user.Habilidades,
                Objetivos = user.Objetivos,
                Jornalista = user.Jornalista,
                CNPJ = user.CNPJ,
                Ramo = user.Ramo,
                Funcionarios = user.Funcionarios,
                Noticias = user.Noticias,
                AvaliacoesEspecialista = user.AvaliacoesEspecialista,
                Posts = user.Posts,
                Comentarios = user.Comentarios,
                LikesPosts = user.LikesPosts,
                CandidatoVagas = user.CandidatoVagas,
                VagaEmpregos = user.VagaEmpregos,
                CandidatosJornalistass = user.CandidatosJornalistass
            };

            return View(model);
        }

        public IActionResult Privacy()
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
