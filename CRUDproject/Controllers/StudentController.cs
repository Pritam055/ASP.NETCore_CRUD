using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDproject.Data;
using CRUDproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDproject.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> studentList = _db.Student;
            return View(studentList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {
            if(ModelState.IsValid)
            {
                _db.Student.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Student.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Student.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Student.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        public IActionResult DeleteStudent(int? id)
        {
            var obj = _db.Student.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Student.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
