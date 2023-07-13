using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace Library_Management_System.Controllers
{

    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Admin_Login_Page()
        {
            return RedirectToAction("Admin_Login", "Home");
        }
        public IActionResult Button()
        {
            return View();

        }
        public IActionResult Available_Books()
        {
            IEnumerable<Book> objBooks = _context.Books;


            return View(objBooks);
        }
        public IActionResult Request_Books()
        {
            return View();
        }
        public IActionResult My_Books()
        {
            var user = Request.Cookies["User"];
            if (user == null)
            {
                return RedirectToAction("Index","Home");
            }
            var userId = Convert.ToInt32(user);

            var books=_context.StudentBooks.Include(a=>a.Book).Where(a=>a.StudentId== userId).ToList();
         


            return View(books);
        }
    }
}
