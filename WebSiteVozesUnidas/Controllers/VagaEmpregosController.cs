using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSiteVozesUnidas.Data;
using WebSiteVozesUnidas.Models;

namespace WebSiteVozesUnidas.Controllers
{
    public class VagaEmpregosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public VagaEmpregosController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: VagaEmpregos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VagaEmpregos.Include(v => v.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> userCandidato()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id; // Obtém o ID do usuário logado

            // Obtém os candidatos associados ao usuário
            var userCandidatos = await _context.CandidatoVagas
                .Where(i => i.IdUsuario == userId)
                .Select(c => c.IdVaga) // Seleciona apenas o IdVaga
                .ToListAsync();

            // Obtém as vagas de emprego correspondentes
            var applicationDbContext = await _context.VagaEmpregos
                .Include(v => v.Usuario)
                .Where(ii => userCandidatos.Contains(ii.IdVagaEmprego)) // Filtra usando Contains
                .ToListAsync();

            return View(applicationDbContext);
        }

        // GET: VagaEmpregos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vagaEmprego = await _context.VagaEmpregos
                .Include(v => v.Usuario)
                .FirstOrDefaultAsync(m => m.IdVagaEmprego == id);
            if (vagaEmprego == null)
            {
                return NotFound();
            }

            return View(vagaEmprego);
        }

        // GET: VagaEmpregos/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: VagaEmpregos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVagaEmprego,Cargo,ResumoVaga,Foto,HorarioExpediente,Beneficios,Requisitos,DescricaoVaga")] VagaEmprego vagaEmprego)
        {
            if (ModelState.IsValid)
            {
                vagaEmprego.IdVagaEmprego = Guid.NewGuid();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                vagaEmprego.UsuarioId = Guid.Parse(userId);
                _context.Add(vagaEmprego);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", vagaEmprego.UsuarioId);
            return View(vagaEmprego);
        }

        // GET: VagaEmpregos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vagaEmprego = await _context.VagaEmpregos.FindAsync(id);
            if (vagaEmprego == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", vagaEmprego.UsuarioId);
            return View(vagaEmprego);
        }

        // POST: VagaEmpregos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdVagaEmprego,Cargo,ResumoVaga,Foto,HorarioExpediente,Beneficios,Requisitos,DescricaoVaga,UsuarioId")] VagaEmprego vagaEmprego)
        {
            if (id != vagaEmprego.IdVagaEmprego)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vagaEmprego);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VagaEmpregoExists(vagaEmprego.IdVagaEmprego))
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
            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id", vagaEmprego.UsuarioId);
            return View(vagaEmprego);
        }

        // GET: VagaEmpregos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vagaEmprego = await _context.VagaEmpregos
                .Include(v => v.Usuario)
                .FirstOrDefaultAsync(m => m.IdVagaEmprego == id);
            if (vagaEmprego == null)
            {
                return NotFound();
            }

            return View(vagaEmprego);
        }

        // POST: VagaEmpregos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var vagaEmprego = await _context.VagaEmpregos.FindAsync(id);
            if (vagaEmprego != null)
            {
                _context.VagaEmpregos.Remove(vagaEmprego);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VagaEmpregoExists(Guid id)
        {
            return _context.VagaEmpregos.Any(e => e.IdVagaEmprego == id);
        }

        //public async Task<IActionResult> userCandidatura()
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    var applicationDbContext = _context.VagaEmpregos.Include(v => v.Usuario);
        //    return View(await applicationDbContext.ToListAsync());
        //}

    }
}
