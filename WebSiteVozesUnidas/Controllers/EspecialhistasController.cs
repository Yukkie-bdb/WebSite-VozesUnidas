﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using WebSiteVozesUnidas.Data;
using WebSiteVozesUnidas.Models;

namespace WebSiteVozesUnidas.Controllers
{
    public class EspecialistaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string _caminho;


        public EspecialistaController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _caminho = hostEnvironment.WebRootPath;
        }


        // GET: Especialista
        public async Task<IActionResult> Index(string nome, string especialidade)
        {
            var especialistas = _context.Especialistas.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                especialistas = especialistas.Where(e => e.Nome.Contains(nome) || e.Email.Contains(nome));
            }

            if (!string.IsNullOrEmpty(especialidade))
            {
                especialistas = especialistas.Where(e => e.Especialhidade.Contains(especialidade));
            }

            return View(await especialistas.ToListAsync());
        }

        [HttpPost]
        public ActionResult IndexPost(string nome, string especialidade)
        {
            // Quando o formulário é enviado, redireciona para a mesma página com os parâmetros
            return RedirectToAction("Index", new { nome = nome, especialidade = especialidade});
        }



        // GET: Especialista/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialhista = await _context.Especialistas
                .FirstOrDefaultAsync(m => m.IdEspecialista == id);
            if (especialhista == null)
            {
                return NotFound();
            }

            ViewBag.Avaliacoes = _context.AvaliacaoEspecialistas.Include(u => u.Usuario).Where(a => a.EspecialistaId == id).ToList();

            ViewBag.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return View(especialhista);
        }

        // GET: Especialista/Create
        [Authorize(Roles = "ADM")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Especialista/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Create([Bind("IdEspecialista,Nome,Telefone,Email,Especialhidade,ImgEspecialista, Usuario")] Especialista especialhista, IFormFile imgUp)
        {
            if (ModelState.IsValid)
            {
                especialhista.IdEspecialista = Guid.NewGuid();
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

        // GET: Especialista/Edit/5
        [Authorize(Roles = "ADM")]
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

        // POST: Especialista/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdEspecialista,Nome,Telefone,Email,Especialhidade,ImgEspecialista, Usuario")] Especialista especialhista, IFormFile imgUp)
        {
            if (id != especialhista.IdEspecialista)
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
                    if (!EspecialistaExists(especialhista.IdEspecialista))
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

        // GET: Especialista/Delete/5
        [Authorize(Roles = "ADM")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var especialhista = await _context.Especialistas
                .FirstOrDefaultAsync(m => m.IdEspecialista == id);
            if (especialhista == null)
            {
                return NotFound();
            }

            return View(especialhista);
        }

        // POST: Especialista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADM")]
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

        private bool EspecialistaExists(Guid id)
        {
            return _context.Especialistas.Any(e => e.IdEspecialista == id);
        }
    }
}
