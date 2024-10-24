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

namespace WebSiteVozesUnidas.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private string _caminho;

        public NoticiasController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
            _caminho = hostEnvironment.WebRootPath;

        }

        public List<Noticia> GetRandomItems(int count)
        {

            var allIds = _context.Noticias.Select(x => x.IdNoticia).ToList();
            var random = new Random();

            var randomIds = allIds.OrderBy(x => random.Next()).Take(count).ToList();

            var randomItems = _context.Noticias 
                                       .Where(x => randomIds.Contains(x.IdNoticia))
                                       .ToList();

            return randomItems;
        }
        public async Task<IActionResult> Index()
        {
            var randomItems = GetRandomItems(3).ToList();
            var i = 0;
            foreach (var item in randomItems)
                {
                    ViewData[i.ToString()] = item.Imagem;
                    ViewData[$"{i}Id"] = item.IdNoticia;
                    ViewData[$"{i}Titulo"] = item.Titulo;

                i++;
                }
            var userid = _signInManager.UserManager.GetUserId(User);
            var Jornalista = await _context.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userid);

            if (userid != null)
            {
                ViewBag.UserId = userid;
                ViewBag.UserJorn = Jornalista.Jornalista;
            }


            return View(await _context.Noticias.ToListAsync());
        }



        // GET: Noticias/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
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
                
            var autor = await _context.Users.FirstOrDefaultAsync(x => x.Id == noticia.IdUsuario);
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
                ViewBag.UserTipo = tipo.Tipo;
            }

            return View(noticia);
        }

        // GET: Noticias/Create
        //[Authorize(Roles = "Admin,Jornalista")]
        public async Task<IActionResult> Create()
        {
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
        public async Task<IActionResult> Create([Bind("IdNoticia,Titulo,Conteudo,Publicacao,IdUsuario")] Noticia noticia, IFormFile imgUp)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                noticia.IdNoticia = Guid.NewGuid();
                noticia.IdUsuario = Guid.Parse(userId);
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
        //[Authorize(Roles = "Admin,Jornalista")]
        
        public async Task<IActionResult> Edit(Guid? id)
        {
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
        public async Task<IActionResult> Edit(Guid id, [Bind("IdNoticia,Titulo,Imagem,Conteudo,Publicacao,IdUsuario")] Noticia noticia, IFormFile? imgUp)
        {
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
                        var noticinha = await _context.Noticias.AsNoTracking().FirstOrDefaultAsync(n => n.IdNoticia == id);
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
        public async Task<IActionResult> Delete(Guid? id)
        {
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
            
            var noticia = await _context.Noticias.FindAsync(id);
            if(name == "Quero Apagar")
            {
                if (noticia != null)
                {
                    _context.Noticias.Remove(noticia);
                }
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
