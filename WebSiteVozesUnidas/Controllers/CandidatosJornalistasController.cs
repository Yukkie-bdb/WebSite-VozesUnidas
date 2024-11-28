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
    public class CandidatosJornalistasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public CandidatosJornalistasController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: CandidatosJornalistas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CandidatosJornalistass.Include(c => c.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CandidatosJornalistas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatosJornalistas = await _context.CandidatosJornalistass
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.IdCandidatosJornalistas == id);
            if (candidatosJornalistas == null)
            {
                return NotFound();
            }

            return View(candidatosJornalistas);
        }

        // GET: CandidatosJornalistas/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: CandidatosJornalistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCandidatosJornalistas,Motivo")] CandidatosJornalistas candidatosJornalistas)
        {
            if (ModelState.IsValid)
            {
                var userId = _signInManager.UserManager.GetUserId(User);
                candidatosJornalistas.UsuarioId = Guid.Parse(userId);
                candidatosJornalistas.IdCandidatosJornalistas = Guid.NewGuid();
                _context.Add(candidatosJornalistas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", candidatosJornalistas.UsuarioId);
            return View(candidatosJornalistas);
        }

        // GET: CandidatosJornalistas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatosJornalistas = await _context.CandidatosJornalistass.FindAsync(id);
            if (candidatosJornalistas == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", candidatosJornalistas.UsuarioId);
            return View(candidatosJornalistas);
        }

        // POST: CandidatosJornalistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdCandidatosJornalistas,Motivo,UsuarioId")] CandidatosJornalistas candidatosJornalistas)
        {
            if (id != candidatosJornalistas.IdCandidatosJornalistas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidatosJornalistas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatosJornalistasExists(candidatosJornalistas.IdCandidatosJornalistas))
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
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", candidatosJornalistas.UsuarioId);
            return View(candidatosJornalistas);
        }

        // GET: CandidatosJornalistas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatosJornalistas = await _context.CandidatosJornalistass
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.IdCandidatosJornalistas == id);
            if (candidatosJornalistas == null)
            {
                return NotFound();
            }

            return View(candidatosJornalistas);
        }

        // POST: CandidatosJornalistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var candidatosJornalistas = await _context.CandidatosJornalistass.FindAsync(id);
            if (candidatosJornalistas != null)
            {
                _context.CandidatosJornalistass.Remove(candidatosJornalistas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatosJornalistasExists(Guid id)
        {
            return _context.CandidatosJornalistass.Any(e => e.IdCandidatosJornalistas == id);
        }

        public async Task<IActionResult> approve(Guid id)
        {
            var candidato = await _context.CandidatosJornalistass.Include(c => c.Usuario).FirstOrDefaultAsync(c => c.UsuarioId == id);

            if (candidato != null)
            {
                var usuario = candidato.Usuario;

                // Adiciona o papel "Jornalista" ao usuário
                var roleAdded = await _userManager.AddToRoleAsync(usuario, "Jornalista");

                if (roleAdded.Succeeded)
                {
                    // Remove o candidato da lista
                    _context.CandidatosJornalistass.Remove(candidato);
                    await _context.SaveChangesAsync();
                    await _signInManager.RefreshSignInAsync(usuario);

                    return RedirectToAction("Index"); // ou a página de onde veio
                }
                else
                {
                    //ModelState.AddModelError("", "Erro ao adicionar a role 'Jornalista'.");
                    return RedirectToAction("Index"); // ou a página de onde veio
                }
            }

            return NotFound();
        }

        public async Task<IActionResult> Disapprove(Guid id)
        {
            var candidato = await _context.CandidatosJornalistass.FirstOrDefaultAsync(c => c.UsuarioId == id);

            if (candidato != null)
            {
                _context.CandidatosJornalistass.Remove(candidato);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
