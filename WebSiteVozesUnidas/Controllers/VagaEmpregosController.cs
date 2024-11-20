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
using WebSiteVozesUnidas.ViewModels;

namespace WebSiteVozesUnidas.Controllers
{
    public class VagaEmpregosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public VagaEmpregosController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: VagaEmpregos
        public async Task<IActionResult> Index(FiltroVagaEmprego filtroVagaEmprego)
        {
            ViewData["CustomHeader"] = "EmpregosHeader";

            var applicationDbContext = _context.VagaEmpregos.Include(v => v.Usuario).AsQueryable();

            if (!string.IsNullOrEmpty(filtroVagaEmprego.Cargo))
                applicationDbContext = applicationDbContext.Where(v => v.Cargo.Contains(filtroVagaEmprego.Cargo));

            if (filtroVagaEmprego.NumeroVagas.HasValue)
            {
                applicationDbContext = applicationDbContext.Where(v => v.NumeroVagas == filtroVagaEmprego.NumeroVagas.Value);
            }

            if (!string.IsNullOrEmpty(filtroVagaEmprego.HorarioExpediente))
            {
                applicationDbContext = applicationDbContext.Where(v => v.HorarioExpediente == filtroVagaEmprego.HorarioExpediente);
            }

            if (!string.IsNullOrEmpty(filtroVagaEmprego.Beneficios))
            {
                applicationDbContext = applicationDbContext.Where(v => v.Beneficios.Contains(filtroVagaEmprego.Beneficios));
            }

            if (!string.IsNullOrEmpty(filtroVagaEmprego.Requisitos))
            {
                applicationDbContext = applicationDbContext.Where(v => v.Requisitos.Contains(filtroVagaEmprego.Requisitos));
            }

            if (!string.IsNullOrEmpty(filtroVagaEmprego.RegimeContratacao))
            {
                applicationDbContext = applicationDbContext.Where(v => v.RegimeContratacao == filtroVagaEmprego.RegimeContratacao);
            }

            if (filtroVagaEmprego.SalarioMin.HasValue)
            {
                applicationDbContext = applicationDbContext.Where(v => v.Salario >= filtroVagaEmprego.SalarioMin.Value);
            }

            if (filtroVagaEmprego.SalarioMax.HasValue)
            {
                applicationDbContext = applicationDbContext.Where(v => v.Salario <= filtroVagaEmprego.SalarioMax.Value);
            }

            if (!string.IsNullOrEmpty(filtroVagaEmprego.LocalTrabalho))
            {
                applicationDbContext = applicationDbContext.Where(v => v.LocalTrabalho.Contains(filtroVagaEmprego.LocalTrabalho));
            }

            if (!string.IsNullOrEmpty(filtroVagaEmprego.Estado))
            {
                applicationDbContext = applicationDbContext.Where(v => v.Estado.Contains(filtroVagaEmprego.Estado));
            }

            if (!string.IsNullOrEmpty(filtroVagaEmprego.Cidade))
            {
                applicationDbContext = applicationDbContext.Where(v => v.Cidade.Contains(filtroVagaEmprego.Cidade));
            }

            if (filtroVagaEmprego.DataPublicacao.HasValue)
            {
                applicationDbContext = applicationDbContext.Where(v => v.Publicacao.Date == filtroVagaEmprego.DataPublicacao.Value.Date);
            }

            if (!string.IsNullOrEmpty(filtroVagaEmprego.Usuario))
            {
                applicationDbContext = applicationDbContext.Where(v => v.Usuario.UserName.Contains(filtroVagaEmprego.Usuario));
            }

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VagaEmpregos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            ViewData["CustomHeader"] = "EmpregosHeader";

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

            ViewData["VagasEmpregos"] = await _context.VagaEmpregos
                .Include(a => a.Usuario)
                .OrderByDescending(vagaEmprego => vagaEmprego.Salario)
                .ToListAsync();

            ViewData["Candidatos"] = await _context.CandidatoVagas
                .Include(a => a.Usuario)
                .ToListAsync();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Obtém a lista de candidaturas do usuário
            var candidaturas = await _context.CandidatoVagas.Where(c => c.VagaEmpregoId == id && c.UsuarioId == Guid.Parse(userId)).ToListAsync() ;

            // Verifica se o usuário já se candidatou
            ViewData["Candidatado"] = candidaturas.Any();

            return View(vagaEmprego);
        }

        // GET: VagaEmpregos/Create
        public IActionResult Create()
        {
            ViewData["CustomHeader"] = "EmpregosHeader";

            ViewData["UsuarioId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: VagaEmpregos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVagaEmprego,Cargo,NumeroVagas,HorarioExpediente,Beneficios,Requisitos,RegimeContratacao,DescricaoVaga,Salario,Estado,Cidade,Publicacao,LocalTrabalho")] VagaEmprego vagaEmprego)
        {
            ViewData["CustomHeader"] = "EmpregosHeader";

            if (ModelState.IsValid)
            {
                var userId = _signInManager.UserManager.GetUserId(User);
                vagaEmprego.UsuarioId = Guid.Parse(userId);
                vagaEmprego.Publicacao = DateTime.Now;
                vagaEmprego.IdVagaEmprego = Guid.NewGuid();
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
            ViewData["CustomHeader"] = "EmpregosHeader";

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
        public async Task<IActionResult> Edit(Guid id, [Bind("IdVagaEmprego,Cargo,NumeroVagas,HorarioExpediente,Beneficios,Requisitos,RegimeContratacao,DescricaoVaga,Salario,Estado,Cidade,Publicacao,UsuarioId")] VagaEmprego vagaEmprego)
        {
            ViewData["CustomHeader"] = "EmpregosHeader";

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
            ViewData["CustomHeader"] = "EmpregosHeader";

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
            ViewData["CustomHeader"] = "EmpregosHeader";

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

        public async Task<IActionResult> VagasCandidatos(Guid Id)
        {
            var userId = Guid.Parse(_signInManager.UserManager.GetUserId(User));
            var candidatos = _context.CandidatoVagas.Include(c => c.Usuario).Include(c => c.VagaEmprego).Where(c => c.VagaEmpregoId == Id);

            return View(await candidatos.ToListAsync());
        }
    }
}
