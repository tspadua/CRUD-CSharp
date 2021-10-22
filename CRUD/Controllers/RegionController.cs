using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    public class RegionController : Controller
    {
        private readonly DatabaseContext _db;

        public RegionController(DatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Region> objList = _db.Regions;
            return View(objList);
        }

        //GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Region obj)
        {
       
            _db.Regions.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
