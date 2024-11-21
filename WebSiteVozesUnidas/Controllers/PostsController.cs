using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WebSiteVozesUnidas.Data;
using WebSiteVozesUnidas.Models;
using static Azure.Core.HttpHeader;

namespace WebSiteVozesUnidas.Controllers
{
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private string _caminho;

        public PostsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
            _caminho = hostEnvironment.WebRootPath;

        }

        // GET: Posts
        public async Task<IActionResult> Index(Guid? id)
        {
            ViewData["CustomHeader"] = "ForumHeader";

            var Categorias = await _context.CategoriaPosts.ToListAsync();
            ViewBag.Categorias = Categorias;
            if(id != null)
            {
                var tudo = await _context.Posts.ToListAsync();
                var filtrado = new List<Post>();
                foreach(var item in tudo)
                {

                    if(item.IdCategoria == id)
                    {
                        filtrado.Add(item);
                    }
                }
                return View(filtrado);

            }

            return View(await _context.Posts.ToListAsync());
        }

        // GET: Posts/Details/5
        public async Task<IActionResult> Details(Guid? id, int? order)
        {
            ViewData["CustomHeader"] = "ForumHeader";
            if (id == null)
            {
                return NotFound();
            }

            var Likes = await _context.LikesPosts.ToListAsync();

            ViewBag.Likes = Likes.Where(l => l.IdPost == id).Count();
            ViewBag.Likonas = Likes;

            var LikesComen = await _context.LikeComens.ToListAsync();

            ViewBag.LikesComen = LikesComen;


            var post = await _context.Posts.FirstOrDefaultAsync(m => m.IdPost == id);
            ViewBag.Image = post.Imagem;    
            var Categorias = await _context.CategoriaPosts.ToListAsync();
            foreach(var item in Categorias)
            {
                if(item.IdCategoriaPost == post.IdCategoria)
                {
                    ViewBag.Categoria = item.Nome;
                }
            }

                    
            if(order == 1 || order is null)
            {
                    var comentariosPost = await _context.Comentarios
                .Where(c => c.IdPost == id)
                .OrderByDescending(c => c.Publicacao)
                .ToListAsync();
                ViewBag.Comentarios = comentariosPost;
            }

            if (order == 2)
            {
                var comentariosPost = await _context.Comentarios
            .Where(c => c.IdPost == id)
            .OrderBy(c => c.Publicacao)
            .ToListAsync();
                ViewBag.Comentarios = comentariosPost;
            }

            


            var usuarios = await _context.Users.ToListAsync();

            ViewBag.Usuarios = usuarios;
            
            var userId = _signInManager.UserManager.GetUserId(User);

            ViewBag.ConnectUserId = userId;

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Comentar([Bind("IdComentario,Publicacao,comentario,IdPost,Id")] Comentario com)
        {
            ViewData["CustomHeader"] = "ForumHeader";
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if(userId != null)
                {
                    com.Id = Guid.Parse(userId);

                }
                else
                {
                    return Redirect("/Identity/Account/Login");
                }
                com.IdComentario = Guid.NewGuid();
                com.Publicacao = DateTime.Now;

                _context.Add(com);
                await _context.SaveChangesAsync();
                return Redirect($"/Posts/Details/{com.IdPost}");
            }
            return NoContent();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Like([Bind("IdLikesPost,IdPost,Id")] LikesPost likesPost)
        {
            ViewData["CustomHeader"] = "ForumHeader";
            if (_signInManager.UserManager.GetUserId(User) is null)
            {
                return Redirect("/Identity/Account/Login");
            }
            likesPost.Id = Guid.Parse(_signInManager.UserManager.GetUserId(User));
            if (ModelState.IsValid)
            {
                var Likes = await _context.LikesPosts.ToListAsync();
                if(Likes.FirstOrDefault(x => x.Id == likesPost.Id && x.IdPost == likesPost.IdPost) != null)
                {
                    var Likado = Likes.FirstOrDefault(x => x.Id == likesPost.Id && x.IdPost == likesPost.IdPost);
                    _context.Remove(Likado);
                    await _context.SaveChangesAsync();
                    return Redirect($"/Posts/Details/{likesPost.IdPost}");
                }
                else
                {
                    likesPost.IdLikesPost = Guid.NewGuid();
                    _context.Add(likesPost);
                    await _context.SaveChangesAsync();
                    return Redirect($"/Posts/Details/{likesPost.IdPost}");
                }
                
            }
            return NoContent();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LikeComent([Bind("IdLikesPost,IdComentario,Id")] LikeComen likeComen, Guid post)
        {
            ViewData["CustomHeader"] = "ForumHeader";
            if (_signInManager.UserManager.GetUserId(User) is null)
            {
                return Redirect("/Identity/Account/Login");
            }
            likeComen.Id = Guid.Parse(_signInManager.UserManager.GetUserId(User));
            if (ModelState.IsValid)
            {
                var Likes = await _context.LikeComens.ToListAsync();
                if (Likes.FirstOrDefault(x => x.Id == likeComen.Id && x.IdComentario == likeComen.IdComentario) != null)
                {
                    var Likado = Likes.FirstOrDefault(x => x.Id == likeComen.Id && x.IdComentario == likeComen.IdComentario);
                    _context.Remove(Likado);
                    await _context.SaveChangesAsync();
                    return Redirect($"/Posts/Details/{post}");
                }
                else
                {
                    likeComen.IdLikeComen = Guid.NewGuid();
                    _context.Add(likeComen);
                    await _context.SaveChangesAsync();
                    return Redirect($"/Posts/Details/{post}");
                }

            }
            return NoContent();
        }






        // GET: Posts/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CustomHeader"] = "ForumHeader";
            var userId = _signInManager.UserManager.GetUserId(User);
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userId);
            var Categorias = await _context.CategoriaPosts.ToListAsync();

            ViewBag.User = user;
            ViewBag.Categorias = Categorias;
            if(userId is null)
            {
                return Redirect("/Identity/Account/Login");
            }
            if (ViewBag.categorias == null)
            {
                ViewBag.categorias = new List<CategoriaPost>();
            }
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPost,Titulo,SubTituloResumo,Conteudo,Publicacao,Id,IdCategoria")] Post post, IFormFile? imgUp)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                post.Id = Guid.Parse(userId);
                post.Publicacao = DateTime.Now;
                post.IdPost = Guid.NewGuid();
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
                    post.Imagem = uniqueFileName;
                }
                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var Categorias = await _context.CategoriaPosts.ToListAsync();
            var Post = await _context.Posts.FindAsync(id);

            ViewBag.Categorias = Categorias;
            
            if (ViewBag.categorias == null)
            {
                ViewBag.categorias = new List<CategoriaPost>();
            }
            ViewBag.id = Post.Imagem;

            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdPost,Titulo,SubTituloResumo,Conteudo,Imagem,Publicacao,Id,IdCategoria")] Post post, IFormFile? imgUp)
        {
            if (id != post.IdPost)
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
                        post.Imagem = uniqueFileName;
                    }
                    else
                    {
                        var postinho = await _context.Posts.AsNoTracking().FirstOrDefaultAsync(n => n.IdPost == id);
                        post.Imagem = postinho.Imagem;
                    }

                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.IdPost))
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

            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, string? name)
        {
            var post = await _context.Posts.FindAsync(id);
            if (name == "Quero Apagar")
            {
                if (post != null)
                {
                    _context.Posts.Remove(post);
                }
                if(post.Imagem != null)
                {
                    string uploadsFolder = Path.Combine(_caminho, "img");

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    string uniqueFileName = post.Imagem;

                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    post.Imagem = uniqueFileName;
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
                var likes = await _context.LikesPosts.ToListAsync();
                foreach (var item in likes)
                {
                    if (item.IdPost == id)
                    {
                        _context.LikesPosts.Remove(item);
                    }
                }

                var comentarios = await _context.Comentarios.ToListAsync();
                foreach (var item in comentarios)
                {
                    if (item.IdPost == id)
                    {
                        var likesComenta = await _context.LikeComens.Where(c => c.IdComentario == item.IdComentario).ToListAsync();
                        foreach(var item2 in likesComenta)
                        {
                            _context.LikeComens.Remove(item2);

                        }
                        _context.Comentarios.Remove(item);
                    }
                }


                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }


            return NoContent();
        }


        private bool PostExists(Guid id)
        {
            return _context.Posts.Any(e => e.IdPost == id);
        }
    }
}
