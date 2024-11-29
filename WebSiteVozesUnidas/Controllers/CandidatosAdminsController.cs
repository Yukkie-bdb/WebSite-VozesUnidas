using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSiteVozesUnidas.Data;
using WebSiteVozesUnidas.Models;

namespace WebSiteVozesUnidas.Controllers
{
    public class CandidatosAdminsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public CandidatosAdminsController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: CandidatosAdmins
        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CandidatosAdminss.Include(c => c.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CandidatosAdmins/Details/5
        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatosAdmins = await _context.CandidatosAdminss
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.IdCandidatosAdmins == id);
            if (candidatosAdmins == null)
            {
                return NotFound();
            }

            return View(candidatosAdmins);
        }

        // GET: CandidatosAdmins/Create
        public IActionResult Create()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Redirect("/Identity/Account/Login");
            }

            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: CandidatosAdmins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCandidatosAdmins,Motivo")] CandidatosAdmins candidatosJornalistas)
        {
            if (string.IsNullOrEmpty(candidatosJornalistas.Motivo))
            {
                TempData["ErrorMessage"] = "Porfavor, informe um motivo!";

                ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", candidatosJornalistas.UsuarioId);
                return View(candidatosJornalistas);
            }

            if (ModelState.IsValid)
            {
                var userId = _signInManager.UserManager.GetUserId(User);

                var candidaturas = _context.CandidatosAdminss.Where(u => u.UsuarioId == Guid.Parse(userId)).ToList();

                if (User.IsInRole("Jornalista"))
                {
                    TempData["ErrorMessage"] = "Você é bobo ou o que? Você já é um Admin nosso! Ou vocês está testando o site? Se for isso bom Trabalho";

                    ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", candidatosJornalistas.UsuarioId);
                    return View(candidatosJornalistas);
                }
                if (candidaturas.Any())
                {
                    TempData["ErrorMessage"] = "Cadastro já realizado, espere um Admin verificar a sua candidadtura!";

                    ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", candidatosJornalistas.UsuarioId);
                    return View(candidatosJornalistas);
                }

                candidatosJornalistas.UsuarioId = Guid.Parse(userId);
                candidatosJornalistas.IdCandidatosAdmins = Guid.NewGuid();
                _context.Add(candidatosJornalistas);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Pa Bens, agora espero um Admin verificar a sua candidatura!";

                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", candidatosJornalistas.UsuarioId);
            return View(candidatosJornalistas);
        }


        // GET: CandidatosAdmins/Edit/5
        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatosAdmins = await _context.CandidatosAdminss.FindAsync(id);
            if (candidatosAdmins == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", candidatosAdmins.UsuarioId);
            return View(candidatosAdmins);
        }

        // POST: CandidatosAdmins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdCandidatosAdmins,Motivo,UsuarioId")] CandidatosAdmins candidatosAdmins)
        {
            if (id != candidatosAdmins.IdCandidatosAdmins)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidatosAdmins);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatosAdminsExists(candidatosAdmins.IdCandidatosAdmins))
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
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", candidatosAdmins.UsuarioId);
            return View(candidatosAdmins);
        }

        // GET: CandidatosAdmins/Delete/5
        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatosAdmins = await _context.CandidatosAdminss
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.IdCandidatosAdmins == id);
            if (candidatosAdmins == null)
            {
                return NotFound();
            }

            return View(candidatosAdmins);
        }

        // POST: CandidatosAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var candidatosAdmins = await _context.CandidatosAdminss.FindAsync(id);
            if (candidatosAdmins != null)
            {
                _context.CandidatosAdminss.Remove(candidatosAdmins);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatosAdminsExists(Guid id)
        {
            return _context.CandidatosAdminss.Any(e => e.IdCandidatosAdmins == id);
        }

        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> approve(Guid id)
        {
            var candidato = await _context.CandidatosAdminss.Include(c => c.Usuario).FirstOrDefaultAsync(c => c.UsuarioId == id);

            if (candidato != null)
            {
                var usuario = candidato.Usuario;

                // Adiciona o papel "Jornalista" ao usuário
                var roleAdded = await _userManager.AddToRoleAsync(usuario, "ADM");

                if (roleAdded.Succeeded)
                {
                    // Remove o candidato da lista
                    _context.CandidatosAdminss.Remove(candidato);
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

        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Disapprove(Guid id)
        {
            var candidato = await _context.CandidatosAdminss.FirstOrDefaultAsync(c => c.UsuarioId == id);

            if (candidato != null)
            {
                _context.CandidatosAdminss.Remove(candidato);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
