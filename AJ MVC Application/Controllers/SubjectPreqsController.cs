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
    public class SubjectPreqsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubjectPreqsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SubjectPreqs
        public async Task<IActionResult> Index()
        {
              return _context.SubjectPreqs != null ? 
                          View(await _context.SubjectPreqs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.SubjectPreqs'  is null.");
        }

        // GET: SubjectPreqs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.SubjectPreqs == null)
            {
                return NotFound();
            }

            var subjectPreq = await _context.SubjectPreqs
                .FirstOrDefaultAsync(m => m.SubjCode == id);
            if (subjectPreq == null)
            {
                return NotFound();
            }

            return View(subjectPreq);
        }

        // GET: SubjectPreqs/Create
        public IActionResult Create()
        {
            ViewBag.Subject = _context.Subjects.ToList();
            return View();
        }

        // POST: SubjectPreqs/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("SubjCode,SubjPreCode,SubjCategory")] SubjectPreq addSubjectPreq)
        {
            var subject = _context.Subjects.FirstOrDefault(s => s.SubjectCode == addSubjectPreq.SubjCode);
            if (subject == null)
            {
                return View(addSubjectPreq);
            }
            
                var subjPreq = new SubjectPreq()
                {
                    SubjCode = addSubjectPreq.SubjCode,
                    SubjPreCode = addSubjectPreq.SubjPreCode,
                    SubjCategory = addSubjectPreq.SubjCategory,
                };

                _context.SubjectPreqs.Add(subjPreq);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: SubjectPreqs/Edit
        public async Task<IActionResult> Edit(string id)
        {
            ViewBag.Subject = _context.Subjects.ToList();
            if (id == null || _context.SubjectPreqs == null)
            {
                return NotFound();
            }

            var subjectPreq = await _context.SubjectPreqs.FindAsync(id);
            if (subjectPreq == null)
            {
                return NotFound();
            }
            return View(subjectPreq);
        }

        // POST: SubjectPreqs/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SubjCode,SubjPreCode,SubjCategory")] SubjectPreq subjectPreq)
        {
            var subject = _context.Subjects.FirstOrDefault(s => s.SubjectCode == subjectPreq.SubjCode);
            if (subject == null)
            {
                return View(subjectPreq);
            }

            if (id != subjectPreq.SubjCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subjectPreq);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectPreqExists(subjectPreq.SubjCode))
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
            return View(subjectPreq);
        }

        // GET: SubjectPreqs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.SubjectPreqs == null)
            {
                return NotFound();
            }

            var subjectPreq = await _context.SubjectPreqs
                .FirstOrDefaultAsync(m => m.SubjCode == id);
            if (subjectPreq == null)
            {
                return NotFound();
            }

            return View(subjectPreq);
        }

        // POST: SubjectPreqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.SubjectPreqs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SubjectPreqs'  is null.");
            }
            var subjectPreq = await _context.SubjectPreqs.FindAsync(id);
            if (subjectPreq != null)
            {
                _context.SubjectPreqs.Remove(subjectPreq);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectPreqExists(string id)
        {
          return (_context.SubjectPreqs?.Any(e => e.SubjCode == id)).GetValueOrDefault();
        }
    }
}
