﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECivisObj.Models;

namespace ECivisWebMVC.Controllers
{
    public class ContactDetailsController : Controller
    {
        private readonly NGORoboticsContext _context;

        public ContactDetailsController(NGORoboticsContext context)
        {
            _context = context;
        }

        // GET: ContactDetails
        public async Task<IActionResult> Index()
        {
            var nGORoboticsContext = _context.ContactDetails.Include(c => c.IdNavigation);
            return View(await nGORoboticsContext.ToListAsync());
        }

        // GET: ContactDetails/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDetails = await _context.ContactDetails
                .Include(c => c.IdNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (contactDetails == null)
            {
                return NotFound();
            }

            return View(contactDetails);
        }

        // GET: ContactDetails/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(_context.Emails, "Id", "Email");
            return View();
        }

        // POST: ContactDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Website")] ContactDetails contactDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Emails, "Id", "Email", contactDetails.Id);
            return View(contactDetails);
        }

        // GET: ContactDetails/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDetails = await _context.ContactDetails.SingleOrDefaultAsync(m => m.Id == id);
            if (contactDetails == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Emails, "Id", "Email", contactDetails.Id);
            return View(contactDetails);
        }

        // POST: ContactDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Website")] ContactDetails contactDetails)
        {
            if (id != contactDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactDetailsExists(contactDetails.Id))
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
            ViewData["Id"] = new SelectList(_context.Emails, "Id", "Email", contactDetails.Id);
            return View(contactDetails);
        }

        // GET: ContactDetails/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDetails = await _context.ContactDetails
                .Include(c => c.IdNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (contactDetails == null)
            {
                return NotFound();
            }

            return View(contactDetails);
        }

        // POST: ContactDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var contactDetails = await _context.ContactDetails.SingleOrDefaultAsync(m => m.Id == id);
            _context.ContactDetails.Remove(contactDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactDetailsExists(long id)
        {
            return _context.ContactDetails.Any(e => e.Id == id);
        }
    }
}
