using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

		
     
        public IActionResult Login()
        {
            return View();
        }
     

        [HttpPost]
        public async Task<IActionResult> Login(Admin admin)
        {
            //var status = _context.tbl_admin.Where(a => a.Username == admin.Username && a.Password == admin.Password).FirstOrDefault();
            //if(status==null)
            //{
            //    ViewBag.LoginStatus = 0;
            //}
            //else
            //{
            //    return RedirectToAction("Button", "Home");
            //}

            if (ModelState.IsValid)
            {
              
                var result = await _signInManager.PasswordSignInAsync(admin.Username, admin.Password,true,false);  

                if (result.Succeeded)
                {
                    return RedirectToAction("Button", "Home");

                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");




            }
            return View(admin);
        }
        [HttpPost]

       
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Home");
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