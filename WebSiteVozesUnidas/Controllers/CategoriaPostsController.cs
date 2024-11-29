using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSiteVozesUnidas.Data;
using WebSiteVozesUnidas.Models;

namespace WebSiteVozesUnidas.Controllers
{
    [Authorize(Roles = "ADM")]
    public class CategoriaPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaPostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaPosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaPosts.ToListAsync());
        }

        // GET: CategoriaPosts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaPost = await _context.CategoriaPosts
                .FirstOrDefaultAsync(m => m.IdCategoriaPost == id);
            if (categoriaPost == null)
            {
                return NotFound();
            }

            return View(categoriaPost);
        }

        // GET: CategoriaPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoriaPost,Nome")] CategoriaPost categoriaPost)
        {
            if (ModelState.IsValid)
            {
                categoriaPost.IdCategoriaPost = Guid.NewGuid();
                _context.Add(categoriaPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaPost);
        }

        // GET: CategoriaPosts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaPost = await _context.CategoriaPosts.FindAsync(id);
            if (categoriaPost == null)
            {
                return NotFound();
            }
            return View(categoriaPost);
        }

        // POST: CategoriaPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdCategoriaPost,Nome")] CategoriaPost categoriaPost)
        {
            if (id != categoriaPost.IdCategoriaPost)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaPostExists(categoriaPost.IdCategoriaPost))
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
            return View(categoriaPost);
        }

        // GET: CategoriaPosts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaPost = await _context.CategoriaPosts
                .FirstOrDefaultAsync(m => m.IdCategoriaPost == id);
            if (categoriaPost == null)
            {
                return NotFound();
            }

            return View(categoriaPost);
        }

        // POST: CategoriaPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var categoriaPost = await _context.CategoriaPosts.FindAsync(id);
            if (categoriaPost != null)
            {
                _context.CategoriaPosts.Remove(categoriaPost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaPostExists(Guid id)
        {
            return _context.CategoriaPosts.Any(e => e.IdCategoriaPost == id);
        }
    }
}
