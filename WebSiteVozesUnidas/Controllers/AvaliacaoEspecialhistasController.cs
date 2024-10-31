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
    public class AvaliacaoEspecialhistasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AvaliacaoEspecialhistasController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;

        }

        // GET: AvaliacaoEspecialhistas
        public async Task<IActionResult> Index()
        {
            var vozesDbContext = _context.AvaliacaoEspecialhistas;
            return View(vozesDbContext.ToList());
        }

        // GET: AvaliacaoEspecialhistas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacaoEspecialhista = await _context.AvaliacaoEspecialhistas
                .Include(a => a.Especialista)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.IdAvaliacaoEspecialhis == id);
            if (avaliacaoEspecialhista == null)
            {
                return NotFound();
            }

            return View(avaliacaoEspecialhista);
        }

        // GET: AvaliacaoEspecialhistas/Create
        public IActionResult Create()
        {
            ViewData["EspecialhistaId"] = new SelectList(_context.Especialistas, "IdEspecialhista", "Nome");
            ViewData["UsuarioId"] = new SelectList(_context.Users, "IdUsuario", "Nome");
            return View();
        }

        // POST: AvaliacaoEspecialhistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAvaliacaoEspecialhis,Descricao,Estrelas,EspecialhistaId, Usuario")] AvaliacaoEspecialhistas avaliacaoEspecialhista)
        {
            //var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UsuarioId");
            //var userId = userIdClaim.Value;

            var userId = _signInManager.UserManager.GetUserId(User);

            if (ModelState.IsValid)
            {

            avaliacaoEspecialhista.UsuarioId = Guid.Parse(userId);
                avaliacaoEspecialhista.IdAvaliacaoEspecialhis = Guid.NewGuid();
                _context.Add(avaliacaoEspecialhista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EspecialhistaId"] = new SelectList(_context.Especialistas, "IdEspecialhista", "Nome", avaliacaoEspecialhista.EspecialhistaId);
            ViewData["UsuarioId"] = new SelectList(_context.Users, "IdUsuario", "Nome", avaliacaoEspecialhista.UsuarioId);
            return View(avaliacaoEspecialhista);
        }

        // GET: AvaliacaoEspecialhistas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacaoEspecialhista = await _context.AvaliacaoEspecialhistas.FindAsync(id);
            if (avaliacaoEspecialhista == null)
            {
                return NotFound();
            }
            ViewData["EspecialhistaId"] = new SelectList(_context.Especialistas, "IdEspecialhista", "Nome", avaliacaoEspecialhista.EspecialhistaId);
            ViewData["UsuarioId"] = new SelectList(_context.Users, "IdUsuario", "Nome", avaliacaoEspecialhista.UsuarioId);
            return View(avaliacaoEspecialhista);
        }

        // POST: AvaliacaoEspecialhistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdAvaliacaoEspecialhis,Descricao,Estrelas,UsuarioId,EspecialhistaId")] AvaliacaoEspecialhistas avaliacaoEspecialhista)
        {
            if (id != avaliacaoEspecialhista.IdAvaliacaoEspecialhis)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avaliacaoEspecialhista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvaliacaoEspecialhistaExists(avaliacaoEspecialhista.IdAvaliacaoEspecialhis))
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
            ViewData["EspecialhistaId"] = new SelectList(_context.Especialistas, "IdEspecialhista", "Nome", avaliacaoEspecialhista.EspecialhistaId);
            ViewData["UsuarioId"] = new SelectList(_context.Users, "IdUsuario", "Nome", avaliacaoEspecialhista.UsuarioId);
            return View(avaliacaoEspecialhista);
        }

        // GET: AvaliacaoEspecialhistas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var avaliacaoEspecialhista = await _context.AvaliacaoEspecialhistas
                .Include(a => a.Especialista)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.IdAvaliacaoEspecialhis == id);
            if (avaliacaoEspecialhista == null)
            {
                return NotFound();
            }

            return View(avaliacaoEspecialhista);
        }

        // POST: AvaliacaoEspecialhistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var avaliacaoEspecialhista = await _context.AvaliacaoEspecialhistas.FindAsync(id);
            if (avaliacaoEspecialhista != null)
            {
                _context.AvaliacaoEspecialhistas.Remove(avaliacaoEspecialhista);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvaliacaoEspecialhistaExists(Guid id)
        {
            return _context.AvaliacaoEspecialhistas.Any(e => e.IdAvaliacaoEspecialhis == id);
        }
    }
}
