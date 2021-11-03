using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TieuLuan.Data;
using TieuLuan.Models;

namespace TieuLuan.Controllers
{
    public class LaptopController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LaptopController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Laptop> List = _db.Laptop;
            return View(List);
        }


        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Laptop lap)
        {
            if (ModelState.IsValid)
            {
                _db.Laptop.Add(lap);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lap);
            
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var lap = _db.Laptop.Find(id);
            if (lap == null)
            {
                return NotFound();
            }
            return View(lap);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Laptop lap)
        {
            if (ModelState.IsValid)
            {
                _db.Laptop.Update(lap);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lap);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var lap = _db.Laptop.Find(id);
            if (lap == null)
            {
                return NotFound();
            }
            return View(lap);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var lap = _db.Laptop.Find(id);
            if (lap == null)
            {
                return NotFound();
                
            }
            _db.Laptop.Remove(lap);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
