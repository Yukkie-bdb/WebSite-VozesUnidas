﻿using System;
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
    public class CandidatoVagasController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public CandidatoVagasController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CandidatoVagas
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id; // Obtém o ID do usuário logado
            ViewData["userId"] = userId;

            return View(await _context.CandidatoVagas.ToListAsync());
        }

        // GET: CandidatoVagas/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatoVaga = await _context.CandidatoVagas
                .FirstOrDefaultAsync(m => m.IdCandidatoVaga == id);
            if (candidatoVaga == null)
            {
                return NotFound();
            }

            return View(candidatoVaga);
        }

        // GET: CandidatoVagas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CandidatoVagas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CandidatoVaga candidatoVaga, Guid Id)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                candidatoVaga.IdCandidatoVaga = Guid.NewGuid();
                candidatoVaga.Id = Guid.Parse(userId);
                candidatoVaga.IdVaga = Id;

                _context.Add(candidatoVaga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidatoVaga);
        }

        // GET: CandidatoVagas/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatoVaga = await _context.CandidatoVagas.FindAsync(id);
            if (candidatoVaga == null)
            {
                return NotFound();
            }
            return View(candidatoVaga);
        }

        // POST: CandidatoVagas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdCandidatoVaga,Id,IdVaga")] CandidatoVaga candidatoVaga)
        {
            if (id != candidatoVaga.IdCandidatoVaga)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidatoVaga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatoVagaExists(candidatoVaga.IdCandidatoVaga))
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
            return View(candidatoVaga);
        }

        // GET: CandidatoVagas/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidatoVaga = await _context.CandidatoVagas
                .FirstOrDefaultAsync(m => m.IdCandidatoVaga == id);
            if (candidatoVaga == null)
            {
                return NotFound();
            }

            return View(candidatoVaga);
        }

        // POST: CandidatoVagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var candidatoVaga = await _context.CandidatoVagas.FindAsync(id);
            if (candidatoVaga != null)
            {
                _context.CandidatoVagas.Remove(candidatoVaga);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatoVagaExists(Guid id)
        {
            return _context.CandidatoVagas.Any(e => e.IdCandidatoVaga == id);
        }

        public async Task<IActionResult> Candidatar(CandidatoVaga candidatoVaga, Guid Id)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Verifica se já existe uma candidatura para o mesmo candidato e vaga
                bool candidaturaExistente = await _context.CandidatoVagas
                    .AnyAsync(cv => cv.Id == Guid.Parse(userId) && cv.IdVaga == Id);

                var vaga = _context.VagaEmpregos.Where(a => a.IdVagaEmprego == Id).FirstOrDefault();

                if (candidaturaExistente)
                {
                    TempData["ErrorMessage"] = $"Erro! Você já se candidatou para a vaga {vaga.Cargo}.";
                    return RedirectToAction("Details", "VagaEmpregos", new { id = Id });
                }

                candidatoVaga.IdCandidatoVaga = Guid.NewGuid();
                candidatoVaga.Id = Guid.Parse(userId);
                candidatoVaga.IdVaga = Id;

                _context.Add(candidatoVaga);
                await _context.SaveChangesAsync();

                // Armazena a mensagem de sucesso em TempData
                TempData["SuccessMessage"] = $"Parabéns! Você acaba de se candidatar a vaga de {vaga.Cargo}.";

                //return Json(new { success = true, message = $"Parabéns! Você acaba de se candidatar a vaga de {Id}." });
                return RedirectToAction("Details", "VagaEmpregos", new { id = Id });

            }
            //return Json(new { success = false, message = "Erro na validação dos dados." });
            TempData["ErrorMessage"] = $"Erro! Não foi possivel realizar a ação.";
            return RedirectToAction("Details", "VagaEmpregos", new { id = Id });

        }
    }
}
