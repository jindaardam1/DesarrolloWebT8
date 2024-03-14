using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ActividadEvaluableUT8MVC.Data;
using ActividadEvaluableUT8MVC.Models;

namespace ActividadEvaluableUT8MVC
{
    public class MasonsController : Controller
    {
        private readonly ActividadEvaluableUT8MVCContext _context;

        public MasonsController(ActividadEvaluableUT8MVCContext context)
        {
            _context = context;
        }

        // GET: Masons
        public async Task<IActionResult> Index()
        {
            var actividadEvaluableUT8MVCContext = _context.Mason.Include(m => m.Logia);
            return View(await actividadEvaluableUT8MVCContext.ToListAsync());
        }

        // GET: Masons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mason = await _context.Mason
                .Include(m => m.Logia)
                .FirstOrDefaultAsync(m => m.MasonId == id);
            if (mason == null)
            {
                return NotFound();
            }

            return View(mason);
        }

        // GET: Masons/Create
        public IActionResult Create()
        {
            ViewData["LogiaId"] = new SelectList(_context.Set<Logia>(), "LogiaId", "LogiaId");
            return View();
        }

        // POST: Masons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MasonId,Name,Description,LogiaId")] Mason mason)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mason);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LogiaId"] = new SelectList(_context.Set<Logia>(), "LogiaId", "LogiaId", mason.LogiaId);
            return View(mason);
        }

        // GET: Masons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mason = await _context.Mason.FindAsync(id);
            if (mason == null)
            {
                return NotFound();
            }
            ViewData["LogiaId"] = new SelectList(_context.Set<Logia>(), "LogiaId", "LogiaId", mason.LogiaId);
            return View(mason);
        }

        // POST: Masons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MasonId,Name,Description,LogiaId")] Mason mason)
        {
            if (id != mason.MasonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mason);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MasonExists(mason.MasonId))
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
            ViewData["LogiaId"] = new SelectList(_context.Set<Logia>(), "LogiaId", "LogiaId", mason.LogiaId);
            return View(mason);
        }

        // GET: Masons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mason = await _context.Mason
                .Include(m => m.Logia)
                .FirstOrDefaultAsync(m => m.MasonId == id);
            if (mason == null)
            {
                return NotFound();
            }

            return View(mason);
        }

        // POST: Masons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mason = await _context.Mason.FindAsync(id);
            _context.Mason.Remove(mason);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MasonExists(int id)
        {
            return _context.Mason.Any(e => e.MasonId == id);
        }
    }
}
