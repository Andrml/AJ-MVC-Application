using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AJ_MVC_Application.Data;
using AJ_MVC_Application.Models;

namespace AJ_MVC_Application.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
              return _context.Students != null ? 
                          View(await _context.Students.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Students'  is null.");
        }

        // GET: Students/Details
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewBag.Course = _context.Courses.ToList();
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("StudentId,StudentFName,StudentLName,StudentMName,StudentCourse,StudentYear,StudentRemarks,StudentStatus")] Student addStudent)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CourseCode == addStudent.StudentCourse);
            if (course == null)
            {
                return View(addStudent);
            }
                var student = new Student()
                {
                    StudentId = addStudent.StudentId,
                    StudentFName = addStudent.StudentFName,
                    StudentLName = addStudent.StudentLName,
                    StudentMName = addStudent.StudentMName,
                    StudentCourse = addStudent.StudentCourse,
                    StudentYear =  addStudent.StudentYear,
                    StudentRemarks = addStudent.StudentRemarks,
                    StudentStatus = "AC",
                };
                
                _context.Students.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.Course = _context.Courses.ToList();
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentId,StudentFName,StudentLName,StudentMName,StudentCourse,StudentYear,StudentRemarks,StudentStatus")] Student editStudent)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CourseCode == editStudent.StudentCourse);
            if (course == null)
            {
                return View(editStudent);
            }
            if (id != editStudent.StudentId)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(editStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(editStudent.StudentId))
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

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Students == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Students'  is null.");
            }
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(string id)
        {
          return (_context.Students?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
