using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Index(FiltroVagaEmprgoNovo filtroVagaEmprego)
        {
            ViewData["CustomHeader"] = "EmpregosHeader";

            var applicationDbContext = _context.VagaEmpregos.Include(v => v.Usuario).AsQueryable();

            // Filtra por Cargo
            if (!string.IsNullOrEmpty(filtroVagaEmprego.Cargo))
            {
                applicationDbContext = applicationDbContext.Where(v => v.Cargo.Contains(filtroVagaEmprego.Cargo));
            }

            // Filtra por Regime de Contratação
            if (!string.IsNullOrEmpty(filtroVagaEmprego.RegimeContratacao))
            {
                applicationDbContext = applicationDbContext.Where(v => v.RegimeContratacao == filtroVagaEmprego.RegimeContratacao);
            }

            // Filtra por Salário
            if (!string.IsNullOrEmpty(filtroVagaEmprego.Salario))
            {
                var salarioString = filtroVagaEmprego.Salario.Trim();
                if (salarioString.EndsWith("+"))
                {
                    if (decimal.TryParse(salarioString.TrimEnd('+'), out var salario))
                    {
                        applicationDbContext = applicationDbContext.Where(v => v.Salario >= salario);
                    }
                }
                else
                {
                    if (decimal.TryParse(salarioString, out var salario))
                    {
                        applicationDbContext = applicationDbContext.Where(v => v.Salario <= salario);
                    }
                }
            }

            // Filtra por Home Office, Hibrido, ou Presencial
            if (filtroVagaEmprego.HomeOffice || filtroVagaEmprego.Hibrido || filtroVagaEmprego.Presencial)
            {
                // Se todos estiverem marcados, exibe todas as vagas (não há filtro específico)
                if (filtroVagaEmprego.HomeOffice && filtroVagaEmprego.Hibrido && filtroVagaEmprego.Presencial)
                {
                    // Não faz nada, pois todas as vagas passam
                }
                else
                {
                    applicationDbContext = applicationDbContext.Where(v =>
                        (filtroVagaEmprego.HomeOffice && v.LocalTrabalho.Contains("Remoto")) ||
                        (filtroVagaEmprego.Hibrido && v.LocalTrabalho.Contains("Hibrido")) ||
                        (filtroVagaEmprego.Presencial && v.LocalTrabalho.Contains("Presencial"))
                    );
                }
            }

            // Filtra por Estado
            if (!string.IsNullOrEmpty(filtroVagaEmprego.Estado))
            {
                applicationDbContext = applicationDbContext.Where(v => v.Estado == filtroVagaEmprego.Estado);
            }

            // Filtra por Cidade
            if (!string.IsNullOrEmpty(filtroVagaEmprego.Cidade))
            {
                applicationDbContext = applicationDbContext.Where(v => v.Cidade.Contains(filtroVagaEmprego.Cidade));
            }

            // Filtra por Data de Publicação
            if (!string.IsNullOrEmpty(filtroVagaEmprego.DataPublicacao) && filtroVagaEmprego.DataPublicacao != "todas")
            {
                DateTime dataFiltro = DateTime.MinValue;

                if (filtroVagaEmprego.DataPublicacao == "hoje")
                {
                    dataFiltro = DateTime.Today;
                    applicationDbContext = applicationDbContext.Where(v => v.Publicacao.Date == dataFiltro.Date);
                }
                else if (filtroVagaEmprego.DataPublicacao == "ultimos2dias")
                {
                    dataFiltro = DateTime.Today.AddDays(-2);
                    applicationDbContext = applicationDbContext.Where(v => v.Publicacao >= dataFiltro);
                }
                else if (filtroVagaEmprego.DataPublicacao == "ultimos3dias")
                {
                    dataFiltro = DateTime.Today.AddDays(-3);
                    applicationDbContext = applicationDbContext.Where(v => v.Publicacao >= dataFiltro);
                }
                else if (filtroVagaEmprego.DataPublicacao == "ultimaSemana")
                {
                    dataFiltro = DateTime.Today.AddDays(-7);
                    applicationDbContext = applicationDbContext.Where(v => v.Publicacao >= dataFiltro);
                }
                else if (filtroVagaEmprego.DataPublicacao == "ultimos15dias")
                {
                    dataFiltro = DateTime.Today.AddDays(-15);
                    applicationDbContext = applicationDbContext.Where(v => v.Publicacao >= dataFiltro);
                }
                else if (filtroVagaEmprego.DataPublicacao == "ultimoMes")
                {
                    dataFiltro = DateTime.Today.AddDays(-30);
                    applicationDbContext = applicationDbContext.Where(v => v.Publicacao >= dataFiltro);
                }
            }

            var categoriaMap = new Dictionary<string, string>
            {
                { "Autônomo", "Autônomo" },
                { "CLT", "CLT (Efetivo)" },
                { "Cooperado", "Cooperado" },
                { "Freelancer", "Free-lancer" },
                { "PJ", "Prestador de serviços (PJ)" },
                { "Temporário", "Temporário" },
                { "Trainee", "Trainee" },
                { "Estágio", "Estágio" }
            };

            // Obtém as categorias de vagas de emprego
            var categorias = _context.VagaEmpregos
                                      .Select(v => v.RegimeContratacao)
                                      .Distinct()
                                      .ToList();

            // Passa o mapeamento e as categorias para a ViewBag
            ViewBag.CategoriaMap = categoriaMap;
            ViewBag.Categorias = categorias;

            ViewBag.vagasRecomendadas = _context.VagaEmpregos.OrderBy(a => a.Salario).Take(9).ToList();

            ViewBag.estados = _context.VagaEmpregos.Select(v => v.Estado).Distinct().OrderBy(x => x).ToList();

            return View(await applicationDbContext.ToListAsync());
        }

        public JsonResult PegarCargos(string query)
        {
            var cargos = _context.VagaEmpregos.Select(v => v.Cargo).Distinct().ToList();

            if (!string.IsNullOrEmpty(query))
            {
                cargos = cargos.Where(c => c.ToLower().Contains(query.ToLower())).ToList();
            }

            return Json(cargos);
        }

        [HttpGet]
        public IActionResult PegarCidadesPorEstado(string estado)
        {
            var cidades = _context.VagaEmpregos
                                  .Where(v => v.Estado == estado)
                                  .Select(v => v.Cidade)
                                  .Distinct()
                                  .OrderBy(x => x)
                                  .ToList();

            return Json(cidades);
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


            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
            {
                ViewData["Candidatado"] = null;
            }
            else
            {
                // Tenta analisar o userId para Guid de forma segura
                if (Guid.TryParse(userId, out Guid parsedUserId))
                {
                    // Obtém a lista de candidaturas do usuário
                    var candidaturas = await _context.CandidatoVagas
                        .Where(c => c.VagaEmpregoId == id && c.UsuarioId == parsedUserId)
                        .ToListAsync();

                    // Verifica se o usuário já se candidatou
                    ViewData["Candidatado"] = candidaturas.Any();
                }
                else
                {
                    // Caso o userId não seja um GUID válido
                    ViewData["Candidatado"] = null;
                }
            }


            if(userId != null && Guid.Parse(userId) == id)
            {
                ViewBag.dono = true;
            }
            else
            {
                ViewBag.dono = false;
            }

            return View(vagaEmprego);
        }

        // GET: VagaEmpregos/Create
        [Authorize(Roles = "ADM, Empresa")]
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
        [Authorize(Roles = "ADM, Empresa")]
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
        [Authorize(Roles = "ADM, Empresa")]
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
        [Authorize(Roles = "ADM, Empresa")]
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
        [Authorize(Roles = "ADM, Empresa")]
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
        [Authorize(Roles = "ADM, Empresa")]
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
