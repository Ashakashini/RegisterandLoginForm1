using Microsoft.AspNetCore.Mvc;

using RegisterandLoginForm.Data;
using RegisterandLoginForm.RegisterandLoginFormDAL;

namespace RegisterandLoginForm.Controllers
{
    public class AccountController : Controller
    {
        private readonly IStudentRepository _repo;

        public AccountController(IStudentRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = _repo.GetStudentByCredentials(username, password);
            if (user != null)
            {
                HttpContext.Session.SetString("UserId", user.StudentId.ToString());
                return RedirectToAction("List", "Student");
            }

            ViewBag.Message = "Invalid credentials";
            return View();
        }
    }
}
