using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebSiteVozesUnidas.Data;
using WebSiteVozesUnidas.Models;

namespace WebSiteVozesUnidas.Controllers
{
    public class EspecialhistasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string _caminho;


        public EspecialhistasController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _caminho = hostEnvironment.WebRootPath;
        }

        // GET: Especialhistas
        public IActionResult Index()
        {
            //var especialistas = _context.Especialistas.Include(e => e.AvaliacoesEspecialhistas).ThenInclude(a => a.Usuario).ToList();

            var especialistas = _context.Especialistas.ToList();
            return View(especialistas ?? new List<Especialista>());
        }




        // GET: Especialhistas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialhista = await _context.Especialistas
                .FirstOrDefaultAsync(m => m.IdEspecialhista == id);
            if (especialhista == null)
            {
                return NotFound();
            }

            return View(especialhista);
        }

        // GET: Especialhistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especialhistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEspecialhista,Nome,Telefone,Email,Especialhidade,ImgEspecialista, Usuario")] Especialista especialhista, IFormFile imgUp)
        {
            if (ModelState.IsValid)
            {
                especialhista.IdEspecialhista = Guid.NewGuid();
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
                    especialhista.ImgEspecialista = uniqueFileName;
                }

                _context.Add(especialhista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialhista);
        }

        // GET: Especialhistas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialhista = await _context.Especialistas.FindAsync(id);
            if (especialhista == null)
            {
                return NotFound();
            }
            return View(especialhista);
        }

        // POST: Especialhistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdEspecialhista,Nome,Telefone,Email,Especialhidade,ImgEspecialista, Usuario")] Especialista especialhista, IFormFile imgUp)
        {
            if (id != especialhista.IdEspecialhista)
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

                        especialhista.ImgEspecialista = uniqueFileName;
                    }

                    _context.Update(especialhista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecialhistaExists(especialhista.IdEspecialhista))
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
            return View(especialhista);
        }

        // GET: Especialhistas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialhista = await _context.Especialistas
                .FirstOrDefaultAsync(m => m.IdEspecialhista == id);
            if (especialhista == null)
            {
                return NotFound();
            }

            return View(especialhista);
        }

        // POST: Especialhistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var especialhista = await _context.Especialistas.FindAsync(id);
            if (especialhista != null)
            {
                _context.Especialistas.Remove(especialhista);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecialhistaExists(Guid id)
        {
            return _context.Especialistas.Any(e => e.IdEspecialhista == id);
        }
    }
}
