using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSiteVozesUnidas.Data;
using WebSiteVozesUnidas.Models;

namespace WebSiteVozesUnidas.Controllers
{
    public class AvaliacaoEspecialistasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AvaliacaoEspecialistasController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: AvaliacaoEspecialistas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AvaliacaoEspecialistas.Include(a => a.Especialistas).Include(a => a.Usuario);
            var avalia = await _context.AvaliacaoEspecialistas.ToListAsync();

            ViewBag.Avaliacoes = avalia;
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AvaliacaoEspecialistas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacaoEspecialista = await _context.AvaliacaoEspecialistas
                .Include(a => a.Especialistas)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.IdAvaliacaoEspecialhis == id);
            if (avaliacaoEspecialista == null)
            {
                return NotFound();
            }

            return View(avaliacaoEspecialista);
        }

        // GET: AvaliacaoEspecialistas/Create
        public IActionResult Create()
        {
            ViewData["EspecialistaId"] = new SelectList(_context.Especialistas, "IdEspecialista", "Nome");
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        // POST: AvaliacaoEspecialistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAvaliacaoEspecialhis,Descricao,Estrelas,EspecialistaId")] AvaliacaoEspecialista avaliacaoEspecialista)
        {

            if (ModelState.IsValid)
            {
                var userId =_userManager.GetUserId(User);
                avaliacaoEspecialista.UsuarioId = Guid.Parse(userId);
                avaliacaoEspecialista.IdAvaliacaoEspecialhis = Guid.NewGuid();
                _context.Add(avaliacaoEspecialista);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Especialista");
            }
            ViewData["EspecialistaId"] = new SelectList(_context.Especialistas, "IdEspecialista", "Nome", avaliacaoEspecialista.EspecialistaId);
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "UserName", avaliacaoEspecialista.UsuarioId);
            return View(avaliacaoEspecialista);
        }

        // GET: AvaliacaoEspecialistas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacaoEspecialista = await _context.AvaliacaoEspecialistas.FindAsync(id);
            if (avaliacaoEspecialista == null)
            {
                return NotFound();
            }
            ViewData["EspecialistaId"] = new SelectList(_context.Especialistas, "IdEspecialista", "Nome", avaliacaoEspecialista.EspecialistaId);
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "UserName", avaliacaoEspecialista.UsuarioId);
            return View(avaliacaoEspecialista);
        }

        // POST: AvaliacaoEspecialistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdAvaliacaoEspecialhis,Descricao,Estrelas,UsuarioId,EspecialistaId")] AvaliacaoEspecialista avaliacaoEspecialista)
        {
            if (id != avaliacaoEspecialista.IdAvaliacaoEspecialhis)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avaliacaoEspecialista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliacaoEspecialistaExists(avaliacaoEspecialista.IdAvaliacaoEspecialhis))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Especialista");
            }
            ViewData["EspecialistaId"] = new SelectList(_context.Especialistas, "IdEspecialista", "Nome", avaliacaoEspecialista.EspecialistaId);
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "UserName", avaliacaoEspecialista.UsuarioId);
            return View(avaliacaoEspecialista);
        }

        // GET: AvaliacaoEspecialistas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacaoEspecialista = await _context.AvaliacaoEspecialistas
                .Include(a => a.Especialistas)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.IdAvaliacaoEspecialhis == id);
            if (avaliacaoEspecialista == null)
            {
                return NotFound();
            }

            return View(avaliacaoEspecialista);
        }

        // POST: AvaliacaoEspecialistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var avaliacaoEspecialista = await _context.AvaliacaoEspecialistas.FindAsync(id);
            if (avaliacaoEspecialista != null)
            {
                _context.AvaliacaoEspecialistas.Remove(avaliacaoEspecialista);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Especialista");
        }

        private bool AvaliacaoEspecialistaExists(Guid id)
        {
            return _context.AvaliacaoEspecialistas.Any(e => e.IdAvaliacaoEspecialhis == id);
        }
    }
}
