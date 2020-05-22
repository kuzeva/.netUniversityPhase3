using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityStudentsApp.Data;
using UniversityStudentsApp.Models;

namespace UniversityStudentsApp.Controllers
{
    public class TeachersController : Controller
    {
        private readonly UniversityStudentsAppContext _context;

        public TeachersController(UniversityStudentsAppContext context)
        {
            _context = context;
        }

        // GET: Teachers
        public async Task<IActionResult> Index(string searchFirstName, string searchLastName, string searchDegree, string searchARank)
        {
            // return View(await _context.Teacher.ToListAsync());
            ViewData["CurrentFilter4"] = searchFirstName;
            ViewData["CurrentFilter5"] = searchLastName;
            ViewData["CurrentFilter6"] = searchDegree;
            ViewData["CurrentFilter7"] = searchARank;

            var teachers = from s in _context.Teacher
                           select s;

            if (!String.IsNullOrEmpty(searchFirstName))
            {
                teachers = teachers.Where(s => s.FirstName.Contains(searchFirstName));
            }
            if (!String.IsNullOrEmpty(searchLastName))
            {
                teachers = teachers.Where(s => s.LastName.Contains(searchLastName));

            }
            if (!String.IsNullOrEmpty(searchDegree))
            {
                teachers = teachers.Where(s => s.Degree.Contains(searchDegree));
            }
            if (!String.IsNullOrEmpty(searchARank))
            {
                teachers = teachers.Where(s => s.AcademicRank.Contains(searchARank));
            }

            teachers = teachers.Include(m => m.FirstTeacherCourses)
                .Include(m => m.SecondTeacherCourses);


            return View(await teachers.AsNoTracking().ToListAsync());
        }
            // GET: Teachers/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher
                .Include(p => p.FirstTeacherCourses)
                .Include(p => p.SecondTeacherCourses)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Degree,AcademicRank,OfficeNumber,HireDate")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Degree,AcademicRank,OfficeNumber,HireDate")] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.Id))
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
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher
                .Include(p => p.FirstTeacherCourses)
                .Include(p => p.SecondTeacherCourses)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher = await _context.Teacher.FindAsync(id);
            _context.Teacher.Remove(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            return _context.Teacher.Any(e => e.Id == id);
        }

        public async Task<IActionResult> GetTeacherById (int? id, int? courseId)
        {
            if(id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher
                .Include(p => p.FirstTeacherCourses)
                    .ThenInclude(p => p.Students).ThenInclude(p => p.Student)
                .Include(p => p.SecondTeacherCourses)
                    .ThenInclude(p => p.Students).ThenInclude(p => p.Student)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            return View(teacher);
        }
            
    }
}
