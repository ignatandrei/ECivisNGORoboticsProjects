using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECivisObj.Models;

namespace ECivisWebMVC.Controllers
{
    public class BenefitsController : Controller
    {
        private readonly NGORoboticsContext _context;

        public BenefitsController(NGORoboticsContext context)
        {
            _context = context;
        }

        // GET: Benefits
        public async Task<IActionResult> Index()
        {
            var nGORoboticsContext = _context.Benefits.Include(b => b.IdroboticEntityNavigation);
            return View(await nGORoboticsContext.ToListAsync());
        }

        // GET: Benefits/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var benefits = await _context.Benefits
                .Include(b => b.IdroboticEntityNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (benefits == null)
            {
                return NotFound();
            }

            return View(benefits);
        }

        // GET: Benefits/Create
        public IActionResult Create()
        {
            ViewData["IdroboticEntity"] = new SelectList(_context.RoboticEntity, "Id", "Name");
            return View();
        }

        // POST: Benefits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,IdroboticEntity")] Benefits benefits)
        {
            if (ModelState.IsValid)
            {
                _context.Add(benefits);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdroboticEntity"] = new SelectList(_context.RoboticEntity, "Id", "Name", benefits.IdroboticEntity);
            return View(benefits);
        }

        // GET: Benefits/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var benefits = await _context.Benefits.SingleOrDefaultAsync(m => m.Id == id);
            if (benefits == null)
            {
                return NotFound();
            }
            ViewData["IdroboticEntity"] = new SelectList(_context.RoboticEntity, "Id", "Name", benefits.IdroboticEntity);
            return View(benefits);
        }

        // POST: Benefits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Description,IdroboticEntity")] Benefits benefits)
        {
            if (id != benefits.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(benefits);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BenefitsExists(benefits.Id))
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
            ViewData["IdroboticEntity"] = new SelectList(_context.RoboticEntity, "Id", "Name", benefits.IdroboticEntity);
            return View(benefits);
        }

        // GET: Benefits/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var benefits = await _context.Benefits
                .Include(b => b.IdroboticEntityNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (benefits == null)
            {
                return NotFound();
            }

            return View(benefits);
        }

        // POST: Benefits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var benefits = await _context.Benefits.SingleOrDefaultAsync(m => m.Id == id);
            _context.Benefits.Remove(benefits);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BenefitsExists(long id)
        {
            return _context.Benefits.Any(e => e.Id == id);
        }
    }
}
