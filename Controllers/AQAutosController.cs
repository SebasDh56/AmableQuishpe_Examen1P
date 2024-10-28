﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AmableQuishpe_Examen1P.Models;

namespace AmableQuishpe_Examen1P.Controllers
{
    public class AQAutosController : Controller
    {
        private readonly AmableQuishpe_Examen1PContext _context;

        public AQAutosController(AmableQuishpe_Examen1PContext context)
        {
            _context = context;
        }

        // GET: AQAutos
        public async Task<IActionResult> Index()
        {
            return View(await _context.AQAuto.ToListAsync());
        }

        // GET: AQAutos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aQAuto = await _context.AQAuto
                .FirstOrDefaultAsync(m => m.AQAutoID == id);
            if (aQAuto == null)
            {
                return NotFound();
            }

            return View(aQAuto);
        }

        // GET: AQAutos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AQAutos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AQAutoID,AQMarca,AQAnio,AQCombustible,AQUsado,AQPrecio,AqEmaildistribuidor,AQFechaIngreso")] AQAuto aQAuto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aQAuto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aQAuto);
        }

        // GET: AQAutos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aQAuto = await _context.AQAuto.FindAsync(id);
            if (aQAuto == null)
            {
                return NotFound();
            }
            return View(aQAuto);
        }

        // POST: AQAutos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AQAutoID,AQMarca,AQAnio,AQCombustible,AQUsado,AQPrecio,AqEmaildistribuidor,AQFechaIngreso")] AQAuto aQAuto)
        {
            if (id != aQAuto.AQAutoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aQAuto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AQAutoExists(aQAuto.AQAutoID))
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
            return View(aQAuto);
        }

        // GET: AQAutos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aQAuto = await _context.AQAuto
                .FirstOrDefaultAsync(m => m.AQAutoID == id);
            if (aQAuto == null)
            {
                return NotFound();
            }

            return View(aQAuto);
        }

        // POST: AQAutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aQAuto = await _context.AQAuto.FindAsync(id);
            if (aQAuto != null)
            {
                _context.AQAuto.Remove(aQAuto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AQAutoExists(int id)
        {
            return _context.AQAuto.Any(e => e.AQAutoID == id);
        }
    }
}
