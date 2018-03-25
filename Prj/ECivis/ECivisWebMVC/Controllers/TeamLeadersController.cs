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
    public class TeamLeadersController : Controller
    {
        private readonly NGORoboticsContext _context;

        public TeamLeadersController(NGORoboticsContext context)
        {
            _context = context;
        }

        // GET: TeamLeaders
        public async Task<IActionResult> Index()
        {
            return View(await _context.TeamLeaders.ToListAsync());
        }

        // GET: TeamLeaders/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamLeaders = await _context.TeamLeaders
                .SingleOrDefaultAsync(m => m.Id == id);
            if (teamLeaders == null)
            {
                return NotFound();
            }

            return View(teamLeaders);
        }

        // GET: TeamLeaders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeamLeaders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Gender")] TeamLeaders teamLeaders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teamLeaders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teamLeaders);
        }

        // GET: TeamLeaders/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamLeaders = await _context.TeamLeaders.SingleOrDefaultAsync(m => m.Id == id);
            if (teamLeaders == null)
            {
                return NotFound();
            }
            return View(teamLeaders);
        }

        // POST: TeamLeaders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,FirstName,LastName,Gender")] TeamLeaders teamLeaders)
        {
            if (id != teamLeaders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teamLeaders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamLeadersExists(teamLeaders.Id))
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
            return View(teamLeaders);
        }

        // GET: TeamLeaders/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teamLeaders = await _context.TeamLeaders
                .SingleOrDefaultAsync(m => m.Id == id);
            if (teamLeaders == null)
            {
                return NotFound();
            }

            return View(teamLeaders);
        }

        // POST: TeamLeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var teamLeaders = await _context.TeamLeaders.SingleOrDefaultAsync(m => m.Id == id);
            _context.TeamLeaders.Remove(teamLeaders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamLeadersExists(long id)
        {
            return _context.TeamLeaders.Any(e => e.Id == id);
        }
    }
}
