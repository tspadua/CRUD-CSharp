using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    public class CharacterController : Controller
    {
        private readonly DatabaseContext _db;

        public CharacterController(DatabaseContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Character> objList = _db.Characters;
            return View(objList);
        }

        //GET CREATE
        public IActionResult Create()
        {
            var characterViewObject = new CharacterViewModel { Regions = _db.Regions };
            return View(characterViewObject);
        }

        //POST CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CharacterViewModel obj)
        {
            var characterFromView = new Character
            {
                Name = obj.Character.Name,
                Description = obj.Character.Description,
                Image = obj.Character.Image,
                RegionId = obj.Character.RegionId
            };
            _db.Characters.Add(characterFromView);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //POST DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var obj = _db.Characters.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Characters.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
