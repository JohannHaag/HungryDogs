using HungryDogs.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using HungryDogs.Contracts.Persistence;
using HungryDogs.AspMvc.Models;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using HungryDogs.AspMvc.Models.Persistence;

namespace HungryDogs.AspMvc.Controllers
{
    public class AppAdminController:Controller
    {
        private readonly ProjectDbContext _context;

        public AppAdminController(ProjectDbContext context)
        {
            _context = context;
        }

        // GET: Restaurant
        public IActionResult Index()
        {
            AppAdmin admin = new AppAdmin();
            admin.Restaurant = _context.Restaurant.ToList();
            admin.OpeningHour = _context.OpeningHour.ToList();
            return View(admin);
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
        public async Task<IActionResult> Create([Bind("Name,OwnerName,UniqueName,Email,State")] Restaurant restaurant)
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

        // GET: OpeningHour/Creates
        public IActionResult Creates(int id = 0)
        {
            if (id == 0)
                return View(new OpeningHour());
            else
                return View(_context.OpeningHour.Find(id));
        }

        // POST: OpeningHour/Creates
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Creates([Bind("Id,Weekday,OpenFrom,OpenTo,Notes,RestaurantId")] OpeningHour openingHour)
        {

            if (ModelState.IsValid)
            {
                if (openingHour.Id == 0)
                    _context.Add(openingHour);
                else
                    _context.Update(openingHour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(openingHour);
        }

        // GET: Restaurant/Edit
        public IActionResult Detail(int id = 0)
        {
            AppAdmin admin = new AppAdmin();
            admin.Restaurants = _context.Restaurant.Find(id);
            return View(admin);
        }

        public IActionResult Details(int id = 0)
        {
            AppAdmin admin = new AppAdmin();
            admin.OpeningHours = _context.OpeningHour.Find(id);
            return View(admin);
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

        // GET: OpeningHour/Edits
        public IActionResult Edits(int id = 0)
        {
            if (id == 0)
                return View(new OpeningHour());
            else
                return View(_context.OpeningHour.Find(id));
        }

        // POST: OpeningHour/Edits
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edits([Bind("Id,Weekday,OpenFrom,OpenTo,Notes,RestaurantId")] OpeningHour openingHour)
        {

            if (ModelState.IsValid)
            {
                if (openingHour.Id == 0)
                    _context.Add(openingHour);
                else
                    _context.Update(openingHour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(openingHour);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int? id)
        {
            var restaurant = _context.Restaurant.Find(id);
            if (restaurant != null)
            {
                _context.Restaurant.Remove(restaurant);
                _context.SaveChangesAsync();
            }
            return View(restaurant);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteR(int? id)
        {
            var restaurant = _context.Restaurant.Find(id);
            if (restaurant != null)
            {
                _context.Restaurant.Remove(restaurant);
                _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [ActionName("Deletes")]
        public async Task<ActionResult> Deletes(int? id)
        {
            var openinghour = _context.OpeningHour.Find(id);
            if (openinghour != null)
            {
                _context.OpeningHour.Remove(openinghour);
                await _context.SaveChangesAsync();
            }
            return View(openinghour);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Deletes")]
        public async Task <ActionResult> DeletesO(int? id)
        {
            var openinghour = _context.OpeningHour.Find(id);
            if (openinghour != null)
            {
                _context.OpeningHour.Remove(openinghour);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
