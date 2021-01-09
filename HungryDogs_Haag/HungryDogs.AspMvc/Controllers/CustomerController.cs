using HungryDogs.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using HungryDogs.Contracts.Persistence;
using HungryDogs.AspMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace HungryDogs.AspMvc.Controllers
{
    public class CustomerController:Controller
    {
        private readonly ProjectDbContext _context;

        public CustomerController(ProjectDbContext context)
        {
            _context = context;
        }

        // GET: Restaurant
        public async Task<IActionResult> Index()
        {
            return View(await _context.Restaurant.ToListAsync());
        }
  

        // GET: Restaurant/Create
        public IActionResult Create(int id = 0)
        {
            if (id == 0)
                return View(new Restaurant());
            else
                return View(_context.Restaurant.Find(id));
        }

        // POST: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,OwnerName,UniqueName,Email,State")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                if (restaurant.Id == 0)
                    _context.Add(restaurant);
                else
                    _context.Update(restaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }


        // GET: Restaurant/Edit
        public IActionResult Detail(int id = 0)
        {
            if (id == 0)
                return View(new Restaurant());
            else
                return View(_context.Restaurant.Find(id));
        }

        // GET: Restaurant/Edit
        public IActionResult Edit(int id = 0)
        {
            if (id == 0)
                return View(new Restaurant());
            else
                return View(_context.Restaurant.Find(id));
        }

        // POST: Restaurant/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Name,OwnerName,UniqueName,Email,State")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                if (restaurant.Id == 0)
                    _context.Add(restaurant);
                else
                    _context.Update(restaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // GET: Restaurant/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            var restaurant = await _context.Restaurant.FindAsync(id);
            _context.Restaurant.Remove(restaurant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
