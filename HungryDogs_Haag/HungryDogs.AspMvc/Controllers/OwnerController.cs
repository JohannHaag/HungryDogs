﻿using HungryDogs.AspMvc.Models;
using HungryDogs.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HungryDogs.AspMvc.Controllers
{
    public class OwnerController : Controller
    {
        private readonly ProjectDbContext _context;

        public OwnerController(ProjectDbContext context)
        {
            _context = context;
        }
        // GET: SpecialOpeningHour
        public async Task<IActionResult> Index()
        {
            return View(await _context.SpecialOpeningHour.ToListAsync());
        }

        // GET: SpecialOpeningHour/Create
        public IActionResult Create(int id = 0)
        {
            if (id == 0)
                return View(new SpecialOpeningHour());
            else
                return View(_context.SpecialOpeningHour.Find(id));
        }

        // POST: SpecialOpeningHour/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,From,To,Notes,State,RestaurantId")] SpecialOpeningHour specialopeningHour)
        {

            if (ModelState.IsValid)
            {
                if (specialopeningHour.Id == 0)
                    _context.Add(specialopeningHour);
                else
                    _context.Update(specialopeningHour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialopeningHour);
        }


        // GET: SpecialOpeningHour/Edit
        public IActionResult Detail(int id = 0)
        {
            if (id == 0)
                return View(new SpecialOpeningHour());
            else
                return View(_context.SpecialOpeningHour.Find(id));
        }

        // GET: SpecialOpeningHour/Edit
        public IActionResult Edit(int id = 0)
        {
            if (id == 0)
                return View(new SpecialOpeningHour());
            else
                return View(_context.SpecialOpeningHour.Find(id));
        }

        // POST: SpecialOpeningHour/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,From,To,Notes,State,RestaurantId")] SpecialOpeningHour specialopeningHour)
        {

            if (ModelState.IsValid)
            {
                if (specialopeningHour.Id == 0)
                    _context.Add(specialopeningHour);
                else
                    _context.Update(specialopeningHour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialopeningHour);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int? id)
        {
            var spopeninghour = _context.SpecialOpeningHour.Find(id);
            if (spopeninghour != null)
            {
                _context.SpecialOpeningHour.Remove(spopeninghour);
                _context.SaveChangesAsync();
            }
            return View(spopeninghour);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteR(int? id)
        {
            var spopeninghour = _context.SpecialOpeningHour.Find(id);
            if (spopeninghour != null)
            {
                _context.SpecialOpeningHour.Remove(spopeninghour);
                _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
