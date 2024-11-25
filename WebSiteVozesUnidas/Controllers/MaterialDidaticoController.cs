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
    public class MaterialDidaticoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private string _caminho;

        public MaterialDidaticoController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _caminho = hostEnvironment.WebRootPath;
        }

        // GET: MaterialDidatico
        public async Task<IActionResult> Index(string? categoriaFiltro)
        {
            ViewBag.categorias = _context.CategoriaMaterials.ToList();

            var vozesDbContext = _context.MaterialDidaticos.Include(m => m.Categoria).AsQueryable();

            var primeiraCategoria = vozesDbContext.Distinct().Select(o => o.Categoria.Categoria).First().ToString();

            if (!string.IsNullOrEmpty(categoriaFiltro))
            {
                vozesDbContext = vozesDbContext.Where(e => e.Categoria.Categoria == categoriaFiltro);
            }
            else
            {
                vozesDbContext = vozesDbContext.Where(e => e.Categoria.Categoria == primeiraCategoria);

            }

            return View(await vozesDbContext.ToListAsync());
        }
        // GET: MaterialDidatico/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialDidatico = await _context.MaterialDidaticos
                .Include(m => m.Categoria)
                .FirstOrDefaultAsync(m => m.IdMaterialDidatico == id);
            if (materialDidatico == null)
            {
                return NotFound();
            }

            return View(materialDidatico);
        }

        // GET: MaterialDidatico/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.CategoriaMaterials, "IdCategoriaMaterial", "Categoria");
            return View();
        }

        // POST: MaterialDidatico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMaterialDidatico,Titulo,Descricao,CategoriaId,LinkYoutube")] MaterialDidatico materialDidatico, IFormFile imgUp)
        {
            if (ModelState.IsValid)
            {
                materialDidatico.IdMaterialDidatico = Guid.NewGuid();
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
                    materialDidatico.ImgMaterial = uniqueFileName;
                }
                _context.Add(materialDidatico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.CategoriaMaterials, "IdCategoriaMaterial", "Categoria", materialDidatico.CategoriaId);
            return View(materialDidatico);
        }

        // GET: MaterialDidatico/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialDidatico = await _context.MaterialDidaticos.FindAsync(id);
            if (materialDidatico == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.CategoriaMaterials, "IdCategoriaMaterial", "Categoria", materialDidatico.CategoriaId);
            return View(materialDidatico);
        }

        // POST: MaterialDidatico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("IdMaterialDidatico,Titulo,Descricao,CategoriaId,ImgMaterial,LinkYoutube")] MaterialDidatico materialDidatico, IFormFile imgUp)
        {
            if (id != materialDidatico.IdMaterialDidatico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Verifica se uma nova imagem foi enviada
                    if (imgUp != null && imgUp.Length > 0)
                    {
                        // Define o diretório onde as imagens são armazenadas
                        string uploadsFolder = Path.Combine(_caminho, "img");

                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        // Gera um nome único para o arquivo
                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + imgUp.FileName;

                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        // Salva a nova imagem no servidor
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await imgUp.CopyToAsync(fileStream);
                        }

                        // Atualiza a propriedade ImgMaterial com o novo nome do arquivo
                        materialDidatico.ImgMaterial = uniqueFileName;
                    }

                    // Atualiza o material didático no contexto
                    _context.Update(materialDidatico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialDidaticoExists(materialDidatico.IdMaterialDidatico))
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

            // Se o modelo não é válido, mantém os dados da categoria
            ViewData["CategoriaId"] = new SelectList(_context.CategoriaMaterials, "IdCategoriaMaterial", "Categoria", materialDidatico.CategoriaId);
            return View(materialDidatico);
        }

        // GET: MaterialDidatico/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialDidatico = await _context.MaterialDidaticos
                .Include(m => m.Categoria)
                .FirstOrDefaultAsync(m => m.IdMaterialDidatico == id);
            if (materialDidatico == null)
            {
                return NotFound();
            }

            return View(materialDidatico);
        }

        // POST: MaterialDidatico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var materialDidatico = await _context.MaterialDidaticos.FindAsync(id);
            if (materialDidatico != null)
            {
                _context.MaterialDidaticos.Remove(materialDidatico);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialDidaticoExists(Guid id)
        {
            return _context.MaterialDidaticos.Any(e => e.IdMaterialDidatico == id);
        }

    }
}
