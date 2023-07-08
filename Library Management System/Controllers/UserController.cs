using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Controllers
{
    [Authorize]
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
            IEnumerable<Book> objBooks = _context.Books;


            return View(objBooks);
        }
    }
}
