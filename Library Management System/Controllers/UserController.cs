using Library_Management_System.Repositories.UserApp;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Admin_Login_Page()
        {
            return RedirectToAction("Admin_Login", "Home");
        }

        public IActionResult Button()
        {
            return View();

        }

        public IActionResult AvailableBooks()
        {
            var result = _userRepository.AvailableBooks();
            return View(result);
        }

        public IActionResult RequestBook()
        {
            return View();
        }

        public IActionResult MyBooks()
        {
            var user = Request.Cookies["User"];
            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var result = _userRepository.MyBooks(user);
            return View(result);
        }
    }
}
