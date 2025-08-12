using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterandLoginDAL;
using RegisterationandLoginDAL;

namespace RegisterandLoginForm.Controllers
{
    public class StudentController : Controller
    {
        private readonly RegisterLoginDBContext _context;

        public StudentController(RegisterLoginDBContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Student student, List<Qualification> qualifications)
        {
            student.Qualifications = student.Qualifications
            .Where(q => !string.IsNullOrWhiteSpace(q.CourseName))
            .ToList();

            if (!ModelState.IsValid)
            {
                try
                {
                    // Add the student first
                    _context.Students.Add(student);
                    _context.SaveChanges();

                    // Add qualifications
                    foreach (var qualification in qualifications)
                    {
                        qualification.StudentId = student.StudentId;
                        _context.Qualifications.Add(qualification);
                    }

                    _context.SaveChanges();

                    return RedirectToAction("List");
                }
                catch (Exception ex)
                {
                    // Log error to console (or to a file, or a logging system like Serilog/NLog)
                    Console.WriteLine($"Error saving to database: {ex.Message}");
                    Console.WriteLine(ex.StackTrace);

                    // Optionally, send error to the view
                    ModelState.AddModelError("", "An error occurred while saving data. Please try again.");
                }
            }

            return View(student);
        }

        public IActionResult List()
        {
            var students = _context.Students
            .Include(s => s.Qualifications)
            .AsNoTracking() 
            .ToList();

            return View(students);
        }
    }
}
