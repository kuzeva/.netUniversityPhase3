using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityStudentsApp.Data;
using UniversityStudentsApp.Models;
using UniversityStudentsApp.ViewModels;

namespace UniversityStudentsApp.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly UniversityStudentsAppContext _context;
        private IWebHostEnvironment webHostEnviroment;


        public EnrollmentsController(UniversityStudentsAppContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnviroment = hostEnvironment;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            var universityStudentsAppContext = _context.Enrollment.Include(e => e.Course).Include(e => e.Student);
            return View(await universityStudentsAppContext.ToListAsync());
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Courses, "Id", "Title");
            ViewData["CourseId"] = new SelectList(_context.Student, "Id", "FirstName");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseId,StudentId,Semester,Year,Grade,SeminalURL,ProjectURL,ExamPoints,SeminalPoints,ProjectPoints,AditionalPoints,FinishDate")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Courses, "Id", "Title", enrollment.StudentId);
            ViewData["CourseId"] = new SelectList(_context.Student, "Id", "FirstName", enrollment.CourseId);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment.FindAsync(id);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Courses, "Id", "Title", enrollment.StudentId);
            ViewData["CourseId"] = new SelectList(_context.Student, "Id", "FirstName", enrollment.CourseId);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseId,StudentId,Semester,Year,Grade,SeminalURL,ProjectURL,ExamPoints,SeminalPoints,ProjectPoints,AditionalPoints,FinishDate")] Enrollment enrollment)
        {
            if (id != enrollment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.Id))
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
            ViewData["StudentId"] = new SelectList(_context.Courses, "Id", "Title", enrollment.StudentId);
            ViewData["CourseId"] = new SelectList(_context.Student, "Id", "FirstName", enrollment.CourseId);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _context.Enrollment.FindAsync(id);
            _context.Enrollment.Remove(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollment.Any(e => e.Id == id);
        }

        public async Task<IActionResult> ProfessorStudentChange(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return View(enrollment);
        }

        [HttpPost]
        public async Task<IActionResult> ProfessorStudentChange(int id)
        {

            if (id.Equals(null))
            {
                return NotFound();
            }

            var enrollmentToUpdate = await _context.Enrollment.FirstOrDefaultAsync(s => s.Id == id);
            if (await TryUpdateModelAsync<Enrollment>(
                enrollmentToUpdate,
                "", s => s.ExamPoints, s => s.SeminarPoints, s => s.ProjectPoints, s => s.AdditionalPoints,
                s => s.Grade, s => s.FinishDate))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(enrollmentToUpdate);

        }
        public async Task<IActionResult> GetStudentsByTeacherCourse(int? Id, int? year = 0)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var enrollment = _context.Enrollment.Where(e => e.CourseId == Id);
            enrollment = enrollment.Include(e => e.Student);
            if (year != 0)
            {
                enrollment = enrollment.Where(e => e.Year == year);
            }


            return View(enrollment);
        }

        private string AddFile(IFormFile file)
        {
            string uniqueFileName = null;

            if (file != null)
            {
                string folderUpload = Path.Combine(webHostEnviroment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                string filePath = Path.Combine(folderUpload, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public async Task<IActionResult> GetStudentByEnrollmentId(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.Student)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }
            return View(enrollment);
        }
        [HttpPost]
        public async Task<IActionResult> GetStudentByEnrollmentId(int? id, IFormFile seminarFile)
        {
            if (id.Equals(null))
            {
                return NotFound();
            }

            int studentId = 1;
            string student = null;
            if (TempData["selectedStudent"] != null)
            {
                student = TempData["selectedStudent"].ToString();
                studentId = Int32.Parse(student);
            }

            var enrollment = await _context.Enrollment.FirstOrDefaultAsync(e => e.Id == id);
            enrollment.SeminarURL = AddFile(seminarFile);
            await TryUpdateModelAsync<Enrollment>(
                enrollment, "", e => e.ProjectURL);

            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction("GetCoursesByStudent", "Enrollments", new { id = studentId });
            }
            catch (DbUpdateException /* ex */)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                "Try again, and if the problem persists, " +
                "see your system administrator.");
            }

            return View(enrollment);
        }

        public async Task<IActionResult> GetCoursesByStudent(int? id)
        {
            if (id.Equals(null))
            {
                return NotFound();
            }
            var students = _context.Enrollment.Where(e => e.StudentId == id);
            students = students.Include(s => s.Course);

            //var student = await _context.Enrollment
            //    .Include(e => e.Student)
            //    .ThenInclude(e => e.Courses)
            //    .FirstOrDefaultAsync(e => e.Student.Id == id);

            return View(students);
        }

        public async Task<IActionResult> Enroll(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = _context.Courses.Where(m => m.Id == id)
               .Include(m => m.Students).First();
            if (course == null)
            {
                return NotFound();
            }
            var EnrollmentEditVM = new EnrollmentViewModel
            {
                Course = course,
                SelectedStudents = course.Students.Select(m => m.StudentId),
                StudentList = new MultiSelectList(_context.Student, "Id", "FullName")
            };
            return View(EnrollmentEditVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enroll(int id, int year, int semester, EnrollmentViewModel viewModel)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    IEnumerable<int> listStudents = viewModel.SelectedStudents;
                    IQueryable<Enrollment> toBeRemoved = _context.Enrollment.Where(s => !listStudents.Contains(s.StudentId) && s.CourseId == id);
                    _context.Enrollment.RemoveRange(toBeRemoved);
                    IEnumerable<int> existStudents = _context.Enrollment.Where(s => listStudents.Contains(s.StudentId) && s.CourseId == id).Select(s => s.StudentId);
                    IEnumerable<int> newStudents = listStudents.Where(s => !existStudents.Contains(s));

                    foreach (int studentId in newStudents)
                        _ = _context.Enrollment.Add(new Enrollment
                        {
                            StudentId = studentId,
                            CourseId = id,
                            Semester = semester,
                            Year = year
                        });

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    throw;

                }
                return RedirectToAction(nameof(CoursesController.Index));
            }
            return View(viewModel);
        }
    }
}
