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
    public class SubjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Subjects
        public async Task<IActionResult> Index()
        {
              return _context.Subjects != null ? 
                          View(await _context.Subjects.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Subjects'  is null.");
        }

        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Subjects == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(m => m.SubjectCode == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subjects/Create
        public IActionResult Create()
        {
            ViewBag.Course = _context.Courses.ToList();
            return View();
        }

        // POST: Subjects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectCode,SubjectDescription,SubjectUnits,SubjectRegOffering,SubjectCategory,SubjectStatus,SubjectCourseCode,SubjectCurrCode")] Subject addSubject)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CourseCode == addSubject.SubjectCourseCode);
            if (course == null)
            {
                return View(addSubject);
            }

            var subject = new Subject()
            {
                SubjectCode = addSubject.SubjectCode,
                SubjectDescription = addSubject.SubjectDescription,
                SubjectUnits = addSubject.SubjectUnits,
                SubjectRegOffering = addSubject.SubjectRegOffering,
                SubjectCategory = addSubject.SubjectCategory,
                SubjectStatus = "AC",
                SubjectCourseCode = addSubject.SubjectCourseCode,
                SubjectCurrCode = addSubject.SubjectCurrCode,
            };

            _context.Subjects.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(string subjectCode, string subjectCategory, string subjectCourseCode)
        {
            ViewBag.Course = _context.Courses.ToList();

            var subject = await _context.Subjects.FindAsync(subjectCode, subjectCategory, subjectCourseCode);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string subjectCode, string subjectCategory, string subjectCourseCode, [Bind("SubjectCode,SubjectDescription,SubjectUnits,SubjectRegOffering,SubjectCategory,SubjectStatus,SubjectCourseCode,SubjectCurrCode")] Subject editSubject)
        {

            if (subjectCode != editSubject.SubjectCode)
            {
                return NotFound();
            }
            if (subjectCategory != editSubject.SubjectCategory)
            {
                return NotFound();
            }
            if (subjectCourseCode != editSubject.SubjectCourseCode)
            {
                return NotFound();
            }

            try
                {
                    _context.Update(editSubject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(editSubject.SubjectCode))
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


        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Subjects == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(m => m.SubjectCode == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Subjects == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Subjects'  is null.");
            }
            var subject = await _context.Subjects.FindAsync(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(string id)
        {
          return (_context.Subjects?.Any(e => e.SubjectCode == id)).GetValueOrDefault();
        }
    }
}
