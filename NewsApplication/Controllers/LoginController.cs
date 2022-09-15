using Microsoft.AspNetCore.Mvc;
using NewsApplication.Models;

namespace NewsApplication.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult loginForm(LoginViewModel login)
        {
            return View();
        }

        public IActionResult StartLoginProcess(LoginViewModel login)
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult RegistrationProcess(Registration registration)
        {
            return View();
        }
    }
}
