using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TieuLuan.Data;
using TieuLuan.Models;

namespace TieuLuan.Controllers
{
    public class PhoneController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PhoneController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Phone> List = _db.Phone;
            return View(List);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Phone ph)
        {
            if (ModelState.IsValid)
            {
                _db.Phone.Add(ph);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ph);

        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var lap = _db.Phone.Find(id);
            if (lap == null)
            {
                return NotFound();
            }
            return View(lap);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Phone ph)
        {
            if (ModelState.IsValid)
            {
                _db.Phone.Update(ph);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ph);

        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var lap = _db.Phone.Find(id);
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
            var ph = _db.Phone.Find(id);
            if (ph == null)
            {
                return NotFound();

            }
            _db.Phone.Remove(ph);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}
