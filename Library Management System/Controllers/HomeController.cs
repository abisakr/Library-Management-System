using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

namespace Library_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Indexx()
        {
            return View();
        }
        public IActionResult privacy()
        {
            return View();
        }
        public IActionResult User_Login_Page()
        {
            var user1 = Request.Cookies["User"];
            if (user1 == null)
            {
                return View();
            }
            return RedirectToAction("Button","User");

        }
        [HttpPost]
        public IActionResult User_Login_Page(User user)
        {
           
            var status = _context.Users.Include(a => a.Student).FirstOrDefault(a => a.Username == user.Username && a.Password == user.Password);
            if (status == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else
            {
                var cookieOptions = new CookieOptions();

                cookieOptions.Expires = DateTime.Now.AddDays(30);
                cookieOptions.Path = "/";
                Response.Cookies.Append("User",Convert.ToString(status.Student.StudentId), cookieOptions);

                return RedirectToAction("Button", "User");
            }

            return View(user);

        }


        [HttpGet]
        public IActionResult Login()
        {
           // var users = _context.tbl_admin.ToList();
            return View();
        }

    
        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            var status = _context.tbl_admin.Where(a => a.Username == admin.Username && a.Password == admin.Password).FirstOrDefault();
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
            //CookieOptions.Expires = DateTime.Now.AddSeconds(1);
            // Session.Abandon();
            //HttpContext.Current.Session.Abandon();
            //string v = Request.Cookies["UserId"];
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(-1d);


            Response.Cookies.Append("User", "null", cookieOptions);
            //var cookieOptions1 = new CookieOptions();
            //cookieOptions1.Expires = DateTime.Now.AddDays(-1d);

            //  Response.Cookies.Append("SomeCookie", "null", cookieOptions);
            //  var UserId = Int32.Parse(Request.Cookies["UserId"]);

            return RedirectToAction(actionName: "Indexx", controllerName: "Home");


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