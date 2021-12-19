using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmkLab.Data;
using SmkLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmkLab.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentsContext _context;
        public StudentsController(StudentsContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.tblstudent.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.tblstudent
                .FirstOrDefaultAsync(m => m.id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FirstName,LastName,Email,Jurusan")] Students students)
        {
            if (ModelState.IsValid)
            {
                _context.tblstudent.Add(students);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.tblstudent.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("FirstName,LastName,Email,Jurusan")] Students students)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(students).State = EntityState.Modified;
                _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(students);

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.tblstudent
                .FirstOrDefaultAsync(m => m.id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Students students = _context.tblstudent.Find(id);
            _context.tblstudent.Remove(students);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
