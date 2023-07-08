using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Library_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;

		public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
			_context = context;
		}
       
        public IActionResult Indexx()
        {
            return View();
        }
       

        public IActionResult User_Login_Page(User user)
		{
			var status = _context.Users.Where(a => a.Username == user.Username && a.Password == user.Password).FirstOrDefault();
			if (status == null)
			{
				ViewBag.LoginStatus = 0;
			}
			else
			{
				return RedirectToAction("Button", "User");
			}

			return View(user);

		}

		public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult View_Books()
        {
            return View();
        }
        public IActionResult Admin_Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Admin_Login(Admin admin)
        {
            var status = _context.tbl_admin.Where(a => a.Username == admin.Username && a.Password == admin.Password).FirstOrDefault();
            if(status==null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                return RedirectToAction("Button", "Home");
            }
           
            return View(admin);
        }
        //[Authorize]
        public IActionResult Button()
        {

            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}