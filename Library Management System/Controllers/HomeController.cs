using Library_Management_System.Data;
using Library_Management_System.Models;
using Library_Management_System.Repositories.Home;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Library_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IHomeRepository homeRepository)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _homeRepository = homeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult UserLoginPage()
        {
            var user1 = Request.Cookies["User"];
            if (user1 == null)
            {
                return View();
            }
            return RedirectToAction("Button", "User");

        }

        [HttpPost]
        public IActionResult UserLoginPage(User user)
        {
            var status = _homeRepository.UserLoginPage(user);
            if (status == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                var cookieOptions = new CookieOptions();
                cookieOptions.Expires = DateTime.Now.AddDays(30);
                cookieOptions.Path = "/";
                Response.Cookies.Append("User", Convert.ToString(status.Student.StudentId), cookieOptions);
                return RedirectToAction("Button", "User");
            }
            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            var status = _homeRepository.Login(admin);
            if (status == null)
            {
                ViewBag.LoginStatus = 0;
                return View(admin);
            }
            else
            {
                return RedirectToAction("Button", "Home");
            }
        }

        public IActionResult LogOut()
        {
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(-1d);
            Response.Cookies.Append("User", "null", cookieOptions);
            return RedirectToAction(actionName: "Index", controllerName: "Home");
        }

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