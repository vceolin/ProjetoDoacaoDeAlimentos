using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoDoacaoDeAlimentos.Data;
using ProjetoDoacaoDeAlimentos.Models;

namespace ProjetoDoacaoDeAlimentos.Controllers
{
    public class RecebedorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecebedorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recebedors
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recebedor.ToListAsync());
        }

        // GET: Recebedors/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recebedor = await _context.Recebedor
                .FirstOrDefaultAsync(m => m.ID == id);
            if (recebedor == null)
            {
                return NotFound();
            }

            return View(recebedor);
        }

        // GET: Recebedors/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recebedors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ID,Email,Cnpj,Endereco")] Recebedor recebedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recebedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recebedor);
        }

        // GET: Recebedors/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recebedor = await _context.Recebedor.FindAsync(id);
            if (recebedor == null)
            {
                return NotFound();
            }
            return View(recebedor);
        }

        // POST: Recebedors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Email,Cnpj,Endereco")] Recebedor recebedor)
        {
            if (id != recebedor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recebedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecebedorExists(recebedor.ID))
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
            return View(recebedor);
        }

        // GET: Recebedors/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recebedor = await _context.Recebedor
                .FirstOrDefaultAsync(m => m.ID == id);
            if (recebedor == null)
            {
                return NotFound();
            }

            return View(recebedor);
        }

        // POST: Recebedors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recebedor = await _context.Recebedor.FindAsync(id);
            _context.Recebedor.Remove(recebedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecebedorExists(int id)
        {
            return _context.Recebedor.Any(e => e.ID == id);
        }
    }
}
