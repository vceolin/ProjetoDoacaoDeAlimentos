﻿using System;
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
    public class AlimentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlimentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alimentos
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alimento.ToListAsync());
        }

        // GET: Alimentos/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alimento = await _context.Alimento
                .FirstOrDefaultAsync(m => m.ID == id);
            if (alimento == null)
            {
                return NotFound();
            }

            return View(alimento);
        }

        // GET: Alimentos/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.Doacao = new SelectList(_context.Doacao, "ID", "ID");

            return View();
        }

        // POST: Alimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DoacaoID,Nome,Tipo,Validade,Observacoes")] Alimento alimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alimento);
        }

        // GET: Alimentos/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Doacao = new SelectList(_context.Doacao, "ID", "ID");

            if (id == null)
            {
                return NotFound();
            }

            var alimento = await _context.Alimento.FindAsync(id);
            if (alimento == null)
            {
                return NotFound();
            }
            return View(alimento);
        }

        // POST: Alimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DoacaoID,Nome,Tipo,Validade,Observacoes")] Alimento alimento)
        {
            if (id != alimento.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlimentoExists(alimento.ID))
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
            return View(alimento);
        }

        // GET: Alimentos/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alimento = await _context.Alimento
                .FirstOrDefaultAsync(m => m.ID == id);
            if (alimento == null)
            {
                return NotFound();
            }

            return View(alimento);
        }

        // POST: Alimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alimento = await _context.Alimento.FindAsync(id);
            _context.Alimento.Remove(alimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlimentoExists(int id)
        {
            return _context.Alimento.Any(e => e.ID == id);
        }
    }
}
