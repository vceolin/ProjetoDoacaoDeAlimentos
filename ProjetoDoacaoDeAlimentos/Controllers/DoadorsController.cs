using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoDoacaoDeAlimentos.Data;
using ProjetoDoacaoDeAlimentos.Models;

namespace ProjetoDoacaoDeAlimentos.Controllers
{
    public class DoadorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DoadorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Doadors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Doador.ToListAsync());
        }

        // GET: Doadors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doador = await _context.Doador
                .FirstOrDefaultAsync(m => m.ID == id);
            if (doador == null)
            {
                return NotFound();
            }

            return View(doador);
        }

        // GET: Doadors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Email,Cnpj,Endereco,TipoEstabelecimento,Pontuacao")] Doador doador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doador);
        }

        // GET: Doadors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doador = await _context.Doador.FindAsync(id);
            if (doador == null)
            {
                return NotFound();
            }
            return View(doador);
        }

        // POST: Doadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Email,Cnpj,Endereco,TipoEstabelecimento,Pontuacao")] Doador doador)
        {
            if (id != doador.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoadorExists(doador.ID))
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
            return View(doador);
        }

        // GET: Doadors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doador = await _context.Doador
                .FirstOrDefaultAsync(m => m.ID == id);
            if (doador == null)
            {
                return NotFound();
            }

            return View(doador);
        }

        // POST: Doadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doador = await _context.Doador.FindAsync(id);
            _context.Doador.Remove(doador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoadorExists(int id)
        {
            return _context.Doador.Any(e => e.ID == id);
        }
    }
}
