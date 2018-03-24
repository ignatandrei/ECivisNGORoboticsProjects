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
    public class PhoneNumbersController : Controller
    {
        private readonly NGORoboticsContext _context;

        public PhoneNumbersController(NGORoboticsContext context)
        {
            _context = context;
        }

        // GET: PhoneNumbers
        public async Task<IActionResult> Index()
        {
            return View(await _context.PhoneNumbers.ToListAsync());
        }

        // GET: PhoneNumbers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneNumbers = await _context.PhoneNumbers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (phoneNumbers == null)
            {
                return NotFound();
            }

            return View(phoneNumbers);
        }

        // GET: PhoneNumbers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhoneNumbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PhoneNumber")] PhoneNumbers phoneNumbers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phoneNumbers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phoneNumbers);
        }

        // GET: PhoneNumbers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneNumbers = await _context.PhoneNumbers.SingleOrDefaultAsync(m => m.Id == id);
            if (phoneNumbers == null)
            {
                return NotFound();
            }
            return View(phoneNumbers);
        }

        // POST: PhoneNumbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PhoneNumber")] PhoneNumbers phoneNumbers)
        {
            if (id != phoneNumbers.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phoneNumbers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneNumbersExists(phoneNumbers.Id))
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
            return View(phoneNumbers);
        }

        // GET: PhoneNumbers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneNumbers = await _context.PhoneNumbers
                .SingleOrDefaultAsync(m => m.Id == id);
            if (phoneNumbers == null)
            {
                return NotFound();
            }

            return View(phoneNumbers);
        }

        // POST: PhoneNumbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var phoneNumbers = await _context.PhoneNumbers.SingleOrDefaultAsync(m => m.Id == id);
            _context.PhoneNumbers.Remove(phoneNumbers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneNumbersExists(long id)
        {
            return _context.PhoneNumbers.Any(e => e.Id == id);
        }
    }
}
