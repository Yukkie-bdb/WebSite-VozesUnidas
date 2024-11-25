using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using WebSiteVozesUnidas.Data;
using WebSiteVozesUnidas.Models;
using Microsoft.AspNetCore.Authorization;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebSiteVozesUnidas.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private string _caminho;
        private readonly UserManager<ApplicationUser> _userManager;
    

        public NoticiasController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _caminho = hostEnvironment.WebRootPath;
            _userManager = userManager;
        }

        public IEnumerable<Noticia> GetRandomItems(int count)
        {

            var allIds = _context.Noticias.Select(x => x.IdNoticia).ToList();
            var random = new Random();

            var randomIds = allIds.OrderBy(x => random.Next()).Take(count).ToList();

            var randomItems = _context.Noticias 
                                       .Where(x => randomIds.Contains(x.IdNoticia))
                                       .ToList();

            return randomItems;
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string userId, string roleName)
        {
            userId = _userManager.GetUserId(User); 
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(roleName))
            {
                return BadRequest("Usuário ou Role inválido.");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                return NoContent();
            }

            ModelState.AddModelError(string.Empty, "Erro ao adicionar a Role.");
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(string userId, string roleName)
        {
            userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(roleName))
            {
                return BadRequest("Usuário ou Role inválido.");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                return NoContent();
            }

            ModelState.AddModelError(string.Empty, "Erro ao remover a Role.");
            return NoContent();
        }
        public async Task<IActionResult> Index(string searchTitle)
        {
            ViewData["CustomHeader"] = "NoticiasHeader";

            var userid = _signInManager.UserManager.GetUserId(User);

            // Carregar todas as notícias antes de filtrar
            var noticias = await _context.Noticias.ToListAsync();

            // Filtrar por título, se o parâmetro de busca for informado
            if (!string.IsNullOrEmpty(searchTitle))
            {
                noticias = noticias.Where(n => n.Titulo.Contains(searchTitle)).ToList(); // Busca parcial no título
            }

            // Obter as notícias de acordo com a quantidade solicitada
            var noticiasExibidas = noticias.ToList();

            // Passa o ID do usuário logado para a ViewBag
            if (userid != null)
            {
                var Jornalista = await _context.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userid);
                ViewBag.UserId = userid;
                ViewBag.UserJorn = Jornalista?.Jornalista;
            }

            var randomItems = GetRandomItems(3).ToList();
            ViewBag.NotNum = noticias.Count();
            if(noticias.Count() != 0)
            {
                ViewBag.noticiasPrincipais = randomItems; // Exibe as notícias principais
            }
            else
            {
                ViewBag.noticiasPrincipais = null;
            }
            //ViewBag.Noticias = noticiasExibidas;
            //ViewBag.NoticiasCarregadas = count;
            //ViewBag.TotalNoticias = noticias.Count(); // Exibe o total de notícias

            if(searchTitle != null)
            {
                ViewBag.PerguntaOuNao = true;
            }
            else
            {
                ViewBag.PerguntaOuNao = false;

            }
            return View(noticiasExibidas);
        }

        //VEJA MAIS VEJA MAIS VEJA MAIS VEJA MAIS VEJA MAIS
        //public async Task<IActionResult> Index(string searchTitle, int count = 7)
        //{
        //    ViewData["CustomHeader"] = "NoticiasHeader";

        //    var userid = _signInManager.UserManager.GetUserId(User);

        //    // Carregar todas as notícias antes de filtrar
        //    var noticias = await _context.Noticias.ToListAsync();

        //    // Filtrar por título, se o parâmetro de busca for informado
        //    if (!string.IsNullOrEmpty(searchTitle))
        //    {
        //        noticias = noticias.Where(n => n.Titulo.Contains(searchTitle)).ToList(); // Busca parcial no título
        //    }

        //    // Obter as notícias de acordo com a quantidade solicitada
        //    var noticiasExibidas = noticias.Take(count).ToList();

        //    // Passa o ID do usuário logado para a ViewBag
        //    if (userid != null)
        //    {
        //        var Jornalista = await _context.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userid);
        //        ViewBag.UserId = userid;
        //        ViewBag.UserJorn = Jornalista?.Jornalista;
        //    }

        //    var randomItems = GetRandomItems(3).ToList();

        //    ViewBag.noticiasPrincipais = randomItems; // Exibe as notícias principais
        //    ViewBag.Noticias = noticiasExibidas;
        //    ViewBag.NoticiasCarregadas = count;
        //    ViewBag.TotalNoticias = noticias.Count(); // Exibe o total de notícias


        //    return View(noticiasExibidas);
        //}
        public async Task<IActionResult> NoticiasPessoais (string searchTitle)
        {
            ViewData["CustomHeader"] = "NoticiasHeader";

            var userid = _signInManager.UserManager.GetUserId(User);

            // Se o parâmetro isUserNews for true, mostramos apenas as notícias do usuário
            var noticias = await _context.Noticias.Where(n => n.Id.ToString() == userid).ToListAsync(); // Apenas as do usuário logado

            // Passa o ID do usuário logado para a ViewBag
            if (userid != null)
            {
                var Jornalista = await _context.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userid);
                ViewBag.UserId = userid;
                ViewBag.UserJorn = Jornalista?.Jornalista;
            }

            // Filtrar por título, se o parâmetro de busca for informado
            if (!string.IsNullOrEmpty(searchTitle))
            {
                noticias = noticias.Where(n => n.Titulo.Contains(searchTitle)).ToList(); // Busca parcial no título
            }

            var randomItems = GetRandomItems(3).ToList();

            ViewBag.noticiasPrincipais = null; // Apenas as do usuário logado

            ViewBag.Noticias = noticias;
            ViewBag.TotalNoticias = _context.Noticias.Where(n => n.Id.ToString() == userid).Count(); // Apenas as do usuário logado

            return View(noticias);
        }

        // GET: Noticias/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            ViewData["CustomHeader"] = "NoticiasHeader";

            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _context.Noticias
                .FirstOrDefaultAsync(m => m.IdNoticia == id);
            if (noticia == null)
            {
                return NotFound();
            }
                
            var autor = await _context.Users.FirstOrDefaultAsync(x => x.Id == noticia.Id);
            var userid = _signInManager.UserManager.GetUserId(User);
            var tipo = await _context.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userid);
            if(autor != null)
            {
                ViewBag.AutorId = autor.Id;
                ViewData["Autor"] = autor.UserName;

            }
            if (userid != null)
            {
                ViewBag.UserId = userid;
            }

            ViewBag.vejaMais = await _context.Noticias.OrderBy(a => a.Publicacao).Take(5).ToListAsync();

            ViewBag.noticias = await _context.Noticias.Take(10).ToListAsync();


            return View(noticia);
        }

        // GET: Noticias/Create
        [Authorize(Roles = "Admin,Jornalista")]
        public async Task<IActionResult> Create()
        {
            ViewData["CustomHeader"] = "NoticiasHeader";

            var userId = _signInManager.UserManager.GetUserId(User);

            if (!string.IsNullOrEmpty(userId) && Guid.TryParse(userId, out var parsedUserId))
            {
                var user = await _context.Users.FindAsync(parsedUserId);
                if (user != null)
                {
                    ViewBag.UserOk = user;
                }
            }

            return View();
        }

        // POST: Noticias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNoticia,SubTitulo,Titulo,Conteudo,Publicacao,Id")] Noticia noticia, IFormFile imgUp)
        {
            ViewData["CustomHeader"] = "NoticiasHeader";

            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                noticia.IdNoticia = Guid.NewGuid();
                noticia.Id = Guid.Parse(userId);
                noticia.Publicacao = DateTime.Now;
                if (imgUp != null && imgUp.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_caminho, "img");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + imgUp.FileName;

                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await imgUp.CopyToAsync(fileStream);
                    }
                    noticia.Imagem = uniqueFileName;
                }
                _context.Add(noticia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(noticia);
        }


        // GET: Noticias/Edit/5
        [Authorize(Roles = "Admin,Jornalista")]
        
        public async Task<IActionResult> Edit(Guid? id)
        {
            ViewData["CustomHeader"] = "NoticiasHeader";

            if (id == null)
            {
                return NotFound();
            }
            var noticia = await _context.Noticias.FindAsync(id);
            if (noticia == null)
            {
                return NotFound();
            }
            ViewBag.id = noticia.Imagem;
            var userid = _signInManager.UserManager.GetUserId(User);

            if (userid != null)
            {
                var userok = await _context.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userid);
                if (userok != null)
                {
                    ViewBag.UserOk = userok;
                }
            }
            
            return View(noticia);
        }

        // POST: Noticias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdNoticia,Titulo,SubTitulo,Imagem,Conteudo,Publicacao")] Noticia noticia, IFormFile? imgUp)
        {
            var noticinha = await _context.Noticias.AsNoTracking().FirstOrDefaultAsync(n => n.IdNoticia == id);
            noticia.Id = noticinha.Id;
            ViewData["CustomHeader"] = "NoticiasHeader";

            if (id != noticia.IdNoticia)
            {
                return NotFound();
            }
 
            if (ModelState.IsValid)
            {
                try
                {
                    if (imgUp != null && imgUp.Length > 0)
                    {
                        string uploadsFolder = Path.Combine(_caminho, "img");

                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + imgUp.FileName;

                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await imgUp.CopyToAsync(fileStream);
                        }
                        noticia.Imagem = uniqueFileName;
                    }
                    else
                    {
                        noticia.Imagem = noticinha.Imagem;
                    }
                    
                    _context.Update(noticia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoticiaExists(noticia.IdNoticia))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(noticia);
        }

        // GET: Noticias/Delete/5
        [Authorize(Roles = "Admin,Jornalista")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            ViewData["CustomHeader"] = "NoticiasHeader";

            if (id == null)
            {
                return NotFound();
            }

            var noticia = await _context.Noticias
                .FirstOrDefaultAsync(m => m.IdNoticia == id);
            if (noticia == null)
            {
                return NotFound();
            }

            return View(noticia);
        }

        // POST: Noticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id,string? name)
        {
            ViewData["CustomHeader"] = "NoticiasHeader";

            var noticia = await _context.Noticias.FindAsync(id);
            if(name == "Quero Apagar")
            {
                if (noticia != null)
                {
                    _context.Noticias.Remove(noticia);
                }
                if(noticia.Imagem != null)
                {
                    string uploadsFolder = Path.Combine(_caminho, "img");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = noticia.Imagem;

                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    noticia.Imagem = uniqueFileName;
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }


            return NoContent();
        }

        private bool NoticiaExists(Guid id)
        {
            return _context.Noticias.Any(e => e.IdNoticia == id);
        }
    }
}
