using Microsoft.AspNetCore.Mvc;
using RegisterandLoginForm.Data;

using RegisterandLoginForm.Models;
using RegisterandLoginForm.RegisterandLoginFormDAL;

public class StudentController : Controller
{
    private readonly IStudentRepository _repository;

    public StudentController(IStudentRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(Student student, List<Qualification> qualifications)
    {
        if (ModelState.IsValid)
        {

            _repository.AddStudentWithQualifications(student, qualifications);
            return RedirectToAction("List");

            
            
        }
        return View(student);
    }

    public IActionResult List()
    {
        var students = _repository.GetAllStudentsWithQualifications();
        return View(students);
    }
}
