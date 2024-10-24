using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSiteVozesUnidas.Data;
using WebSiteVozesUnidas.Models;

namespace WebSiteVozesUnidas.Controllers
{
    public class LikesPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LikesPostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LikesPosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.LikesPosts.ToListAsync());
        }

        // GET: LikesPosts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var likesPost = await _context.LikesPosts
                .FirstOrDefaultAsync(m => m.IdLikesPost == id);
            if (likesPost == null)
            {
                return NotFound();
            }

            return View(likesPost);
        }

        // GET: LikesPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LikesPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLikesPost,IdPost,IdUsuario")] LikesPost likesPost)
        {
            if (ModelState.IsValid)
            {
                likesPost.IdLikesPost = Guid.NewGuid();
                _context.Add(likesPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(likesPost);
        }

        // GET: LikesPosts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var likesPost = await _context.LikesPosts.FindAsync(id);
            if (likesPost == null)
            {
                return NotFound();
            }
            return View(likesPost);
        }

        // POST: LikesPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdLikesPost,IdPost,IdUsuario")] LikesPost likesPost)
        {
            if (id != likesPost.IdLikesPost)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(likesPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LikesPostExists(likesPost.IdLikesPost))
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
            return View(likesPost);
        }

        // GET: LikesPosts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var likesPost = await _context.LikesPosts
                .FirstOrDefaultAsync(m => m.IdLikesPost == id);
            if (likesPost == null)
            {
                return NotFound();
            }

            return View(likesPost);
        }

        // POST: LikesPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var likesPost = await _context.LikesPosts.FindAsync(id);
            if (likesPost != null)
            {
                _context.LikesPosts.Remove(likesPost);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LikesPostExists(Guid id)
        {
            return _context.LikesPosts.Any(e => e.IdLikesPost == id);
        }
    }
}
