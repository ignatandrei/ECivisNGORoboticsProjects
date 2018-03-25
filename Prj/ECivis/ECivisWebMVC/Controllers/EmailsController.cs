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
    public class EmailsController : Controller
    {
        private readonly NGORoboticsContext _context;

        public EmailsController(NGORoboticsContext context)
        {
            _context = context;
        }

        // GET: Emails
        public async Task<IActionResult> Index()
        {
            return View(await _context.Emails.ToListAsync());
        }

        // GET: Emails/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emails = await _context.Emails
                .SingleOrDefaultAsync(m => m.Id == id);
            if (emails == null)
            {
                return NotFound();
            }

            return View(emails);
        }

        // GET: Emails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Emails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Email,IdcontactDetails")] Emails emails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emails);
        }

        // GET: Emails/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emails = await _context.Emails.SingleOrDefaultAsync(m => m.Id == id);
            if (emails == null)
            {
                return NotFound();
            }
            return View(emails);
        }

        // POST: Emails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Type,Email,IdcontactDetails")] Emails emails)
        {
            if (id != emails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailsExists(emails.Id))
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
            return View(emails);
        }

        // GET: Emails/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emails = await _context.Emails
                .SingleOrDefaultAsync(m => m.Id == id);
            if (emails == null)
            {
                return NotFound();
            }

            return View(emails);
        }

        // POST: Emails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var emails = await _context.Emails.SingleOrDefaultAsync(m => m.Id == id);
            _context.Emails.Remove(emails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmailsExists(long id)
        {
            return _context.Emails.Any(e => e.Id == id);
        }
    }
}
