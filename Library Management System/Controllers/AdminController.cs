using AutoMapper;
using Library_Management_System.DTO;
using Library_Management_System.Models;
using Library_Management_System.Repositories.AdminApp;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAdminRepository _adminRepository;

        public AdminController(IMapper mapper, IAdminRepository adminRepository)
        {
            _mapper = mapper;
            _adminRepository = adminRepository;
        }
        public IActionResult ManageBook()
        {
            var result = _adminRepository.GetAllBooks();
            return View(result);
        }

        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(BookDto book)
        {
            if (ModelState.IsValid)
            {
                _adminRepository.AddBook(book);
                TempData["Success"] = "Book Added Sucessfully";
                return RedirectToAction("ManageBook", "Admin");
            }
            return View(book);
        }

        public IActionResult EditBook(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var book = _adminRepository.FindBookById(id);
            if (book == null)
                return NotFound();
            return View(book);

        }
        [HttpPost]
        public IActionResult EditBook(BookDto book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _adminRepository.EditBook(book);
                    TempData["success"] = "Book Edited Successfully";
                    return RedirectToAction("ManageBook");
                }
                return NotFound();
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e);
            }
        }

        public IActionResult DeleteBook(int? id)
        {
            var book = _adminRepository.FindBookById(id);
            if (book == null)
                return NotFound();
            return View(book);
        }

        [HttpPost]
        public IActionResult DeleteBook(Book book)
        {
            var result = _adminRepository.DeleteBook(book);
            if (result == true)
            {
                TempData["success"] = "Book Deleted Sucessfully";
                return RedirectToAction("ManageBook");
            }
            return NotFound();
        }

        public IActionResult IssueBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IssueBook(IssueBookDto issue)
        {
            if (ModelState.IsValid)
            {
                _adminRepository.IssueBook(issue);
                TempData["success"] = "Book Issued Successfully";
                return RedirectToAction("Button", "Home");
            }
            return View(issue);
        }

        public IActionResult Return()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Return(IssueBookDto issueBook)
        {
            if (ModelState.IsValid)
            {
                _adminRepository.Return(issueBook);
                TempData["success"] = "Book Returned Successfully";
                return RedirectToAction("Button", "Home");
            }
            return View(issueBook);
        }

        public IActionResult ManageStudents()
        {
            var result = _adminRepository.GetAllStudents();
            return View(result);

        }

        public IActionResult EditStudent(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var student = _adminRepository.FindStudentById(id);
            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        public IActionResult EditStudent(StudentDto student)
        {
            if (ModelState.IsValid)
            {
                _adminRepository.EditStudent(student);
                TempData["success"] = "Book Edited Successfully";
                return RedirectToAction("ManageStudents");
            }
            return NotFound();
        }


        public IActionResult IssueRequest()
        {
            var result = _adminRepository.GetAllBooks();
            return View(result);
        }

        public IActionResult ManageUser()
        {
            //get all user
            var result = _adminRepository.GetAllUsers();
            return View(result);
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UserDto user)
        {
            var userView = _mapper.Map<User>(user);
            if (ModelState.IsValid)
            {
                _adminRepository.AddUser(user);
                TempData["success"] = "User Added Successfully";
                return RedirectToAction("ManageUser", "Admin");
            }
            return View(userView);
        }

        public IActionResult BooksTaken()
        {
            var result = _adminRepository.BooksTaken();
            return View(result);
        }

        public IActionResult DeleteUser(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var userFromDb = _adminRepository.FindUserById(id);
            if (userFromDb == null)
            {
                return NotFound();
            }
            return View(userFromDb);
        }

        [HttpPost]
        public IActionResult DeleteUser(User user)
        {
            if (user.UserId == 0)
                return NotFound();
            var userFromDb = _adminRepository.FindUserById(user.UserId);

            if (user == null)
                return NotFound();
            _adminRepository.DeleteUser(userFromDb);
            TempData["success"] = "User Deleted Successfully";
            return RedirectToAction("ManageUser");
        }

        public IActionResult EditUser(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var userFromDb = _adminRepository.FindUserById(id);
            if (userFromDb == null)
                return NotFound();
            return View(userFromDb);
        }

        [HttpPost]
        public IActionResult EditUser(User user)
        {
            if (!ModelState.IsValid)
            {
                _adminRepository.EditUser(user);
                TempData["success"] = "User Edited Successfully";
                return RedirectToAction("ManageUser");
            }
            return NotFound();
        }
    }
}



