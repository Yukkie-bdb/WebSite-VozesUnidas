﻿using System;
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
    public class ComentariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComentariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Comentarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comentarios.ToListAsync());
        }

        // GET: Comentarios/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios
                .FirstOrDefaultAsync(m => m.IdComentario == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // GET: Comentarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comentarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdComentario,Publicacao,comentario,IdPost,Id")] Comentario comentario)
        {
            if (ModelState.IsValid)
            {
                comentario.IdComentario = Guid.NewGuid();
                _context.Add(comentario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comentario);
        }

        // GET: Comentarios/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }
            return View(comentario);
        }

        // POST: Comentarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdComentario,Publicacao,comentario,IdPost,IdUsuario")] Comentario com, Guid post,Guid IdUsuario)
        {
            com.IdComentario = id;
            if (id != com.IdComentario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                com.Id = IdUsuario;
                try
                {
                    _context.Update(com);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComentarioExists(com.IdComentario))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect($"/Posts/Details/{post}");
            }
            return NoContent();
        }

        // GET: Comentarios/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios
                .FirstOrDefaultAsync(m => m.IdComentario == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // POST: Comentarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, string? name, Guid post)
        {
            if (name == "Quero Apagar")
            {
                var comentario = await _context.Comentarios.FindAsync(id);
                if (comentario != null)
                {
                    _context.Comentarios.Remove(comentario);
                }
                var likes = await _context.LikeComens.ToListAsync();
                foreach (var item in likes)
                {
                    if(item.IdComentario == id)
                    {
                        _context.LikeComens.Remove(item);
                    }
                }

                await _context.SaveChangesAsync();
                return Redirect($"/Posts/Details/{post}");
            }
            return NoContent();
        }

        private bool ComentarioExists(Guid id)
        {
            return _context.Comentarios.Any(e => e.IdComentario == id);
        }
    }
}

