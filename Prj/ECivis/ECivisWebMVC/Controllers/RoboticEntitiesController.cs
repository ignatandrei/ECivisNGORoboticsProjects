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
    public class RoboticEntitiesController : Controller
    {
        private readonly NGORoboticsContext _context;

        public RoboticEntitiesController(NGORoboticsContext context)
        {
            _context = context;
        }

        // GET: RoboticEntities
        public async Task<IActionResult> Index()
        {
            var nGORoboticsContext = _context.RoboticEntity.Include(r => r.IdaddressNavigation).Include(r => r.IdcategoryNavigation).Include(r => r.IdcontactDetailsNavigation);
            return View(await nGORoboticsContext.ToListAsync());
        }

        // GET: RoboticEntities/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticEntity = await _context.RoboticEntity
                .Include(r => r.IdaddressNavigation)
                .Include(r => r.IdcategoryNavigation)
                .Include(r => r.IdcontactDetailsNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticEntity == null)
            {
                return NotFound();
            }

            return View(roboticEntity);
        }

        // GET: RoboticEntities/Create
        public IActionResult Create()
        {
            ViewData["Idaddress"] = new SelectList(_context.Address, "Id", "AddressDetails");
            ViewData["Idcategory"] = new SelectList(_context.Category, "Id", "Name");
            ViewData["IdcontactDetails"] = new SelectList(_context.ContactDetails, "Id", "Id");
            return View();
        }

        // POST: RoboticEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Idaddress,Idcategory,Description,MemberCount,Rating,IdcontactDetails,WomenPercentage,Sentiment")] RoboticEntity roboticEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roboticEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idaddress"] = new SelectList(_context.Address, "Id", "AddressDetails", roboticEntity.Idaddress);
            ViewData["Idcategory"] = new SelectList(_context.Category, "Id", "Name", roboticEntity.Idcategory);
            ViewData["IdcontactDetails"] = new SelectList(_context.ContactDetails, "Id", "Id", roboticEntity.IdcontactDetails);
            return View(roboticEntity);
        }

        // GET: RoboticEntities/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticEntity = await _context.RoboticEntity.SingleOrDefaultAsync(m => m.Id == id);
            if (roboticEntity == null)
            {
                return NotFound();
            }
            ViewData["Idaddress"] = new SelectList(_context.Address, "Id", "AddressDetails", roboticEntity.Idaddress);
            ViewData["Idcategory"] = new SelectList(_context.Category, "Id", "Name", roboticEntity.Idcategory);
            ViewData["IdcontactDetails"] = new SelectList(_context.ContactDetails, "Id", "Id", roboticEntity.IdcontactDetails);
            return View(roboticEntity);
        }

        // POST: RoboticEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Idaddress,Idcategory,Description,MemberCount,Rating,IdcontactDetails,WomenPercentage,Sentiment")] RoboticEntity roboticEntity)
        {
            if (id != roboticEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roboticEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoboticEntityExists(roboticEntity.Id))
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
            ViewData["Idaddress"] = new SelectList(_context.Address, "Id", "AddressDetails", roboticEntity.Idaddress);
            ViewData["Idcategory"] = new SelectList(_context.Category, "Id", "Name", roboticEntity.Idcategory);
            ViewData["IdcontactDetails"] = new SelectList(_context.ContactDetails, "Id", "Id", roboticEntity.IdcontactDetails);
            return View(roboticEntity);
        }

        // GET: RoboticEntities/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roboticEntity = await _context.RoboticEntity
                .Include(r => r.IdaddressNavigation)
                .Include(r => r.IdcategoryNavigation)
                .Include(r => r.IdcontactDetailsNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (roboticEntity == null)
            {
                return NotFound();
            }

            return View(roboticEntity);
        }

        // POST: RoboticEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var roboticEntity = await _context.RoboticEntity.SingleOrDefaultAsync(m => m.Id == id);
            _context.RoboticEntity.Remove(roboticEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoboticEntityExists(long id)
        {
            return _context.RoboticEntity.Any(e => e.Id == id);
        }
    }
}
