using Microsoft.AspNetCore.Mvc;



using RegisterationandLoginDAL;

namespace RegisterandLoginForm.Controllers
{
    public class AccountController : Controller
    {
        private readonly RegisterLoginDBContext _context;

        public AccountController(RegisterLoginDBContext context)
        {
            _context = context;
        }

        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = _context.Students
                .FirstOrDefault(s => s.Username == username && s.Password == password); // adjust if column names differ

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
