using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECivisObj.Models;

namespace ECivisWeb.Controllers
{
    public class NgousersController : Controller
    {
        private readonly NGORoboticsContext _context;

        public NgousersController(NGORoboticsContext context)
        {
            _context = context;
        }

        // GET: Ngousers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ngouser.ToListAsync());
        }

        // GET: Ngousers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngouser = await _context.Ngouser
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ngouser == null)
            {
                return NotFound();
            }

            return View(ngouser);
        }

        // GET: Ngousers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ngousers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Password")] Ngouser ngouser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ngouser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ngouser);
        }

        // GET: Ngousers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngouser = await _context.Ngouser.SingleOrDefaultAsync(m => m.Id == id);
            if (ngouser == null)
            {
                return NotFound();
            }
            return View(ngouser);
        }

        // POST: Ngousers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Password")] Ngouser ngouser)
        {
            if (id != ngouser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ngouser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NgouserExists(ngouser.Id))
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
            return View(ngouser);
        }

        // GET: Ngousers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ngouser = await _context.Ngouser
                .SingleOrDefaultAsync(m => m.Id == id);
            if (ngouser == null)
            {
                return NotFound();
            }

            return View(ngouser);
        }

        // POST: Ngousers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var ngouser = await _context.Ngouser.SingleOrDefaultAsync(m => m.Id == id);
            _context.Ngouser.Remove(ngouser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NgouserExists(long id)
        {
            return _context.Ngouser.Any(e => e.Id == id);
        }
    }
}
