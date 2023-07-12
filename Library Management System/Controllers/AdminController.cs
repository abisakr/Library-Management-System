using AutoMapper;
using Library_Management_System.Data;
using Library_Management_System.DTO;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    // [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AdminController(ApplicationDbContext context, IMapper mapper, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Manage_Book()
        {
            IEnumerable<Book> objBooks = _context.Books;


            return View(objBooks);
        }
        public IActionResult Add_Book()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add_Book(Book book)
        {




            if (!ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                TempData["success"] = "Book Added Successfully";
                return RedirectToAction("Manage_Book", "Admin");
            }
            return View(book);

        }
        public IActionResult Edit_Book(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var book = _context.Books.Find(id);
            if (book == null)
                return NotFound();

            return View(book);

        }
        [HttpPost]
        public IActionResult EditBook(Book book)
        {

            if (!ModelState.IsValid)
            {
                _context.Update(book);
                _context.SaveChanges();
             
                TempData["success"] = "Book Edited Successfully";

                return RedirectToAction("Manage_Book");
            }
            return NotFound();
        }

        public IActionResult Delete_Book(int? id)
        {
            // if (id == null || id == 0)
            // return NotFound();
            var book = _context.Books.Find(id);
            if (book == null)
                return NotFound();

            return View(book);

        }
        [HttpPost]
        public IActionResult DeleteBook(Book book)
        {
            if (book.BookId == null || book.BookId == 0)
                return NotFound();
            var book1 = _context.Books.Find(book.BookId);
            if (book == null)
                return NotFound();
            _context.Books.Remove(book1);
            _context.SaveChanges();
            TempData["success"] = "Book Deleted Successfully";
            return RedirectToAction("Manage_Book");


        }
        public IActionResult Issue_Book()
        {

            return View();


        }
        [HttpPost]
        public IActionResult Issue_Book(IssueBookDto issue)
        {
            if (ModelState.IsValid)
            {


                var book = _context.Books.Where(x => x.BookId == issue.BookId).ToList().FirstOrDefault();

                var student = _context.Students.Where(x => x.StudentId == issue.StudentId).ToList().FirstOrDefault();

                var studentBook = new StudentBook();

                studentBook.Student = student;
                studentBook.Book = book;
                _context.StudentBooks.Add(studentBook);
                _context.SaveChanges();
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
        public IActionResult Return(IssueBookDto issue)
        {
            if (ModelState.IsValid)
            {

                //  StudentBook  Issue = _mapper.Map < IssueBookDto, Student > (issue) ;
                //var mapper = _mapper.Map<Student>(issue);
                //var mapper1 = _mapper.Map<Book>(issue);



                //_context.Students.Add(mapper);



                //_context.SaveChanges();
                //_context.Books.Add(mapper1);
                //_context.SaveChanges();

                var book = _context.Books.Where(x => x.BookId == issue.BookId).ToList().FirstOrDefault();

                var student = _context.Students.Where(x => x.StudentId == issue.StudentId).ToList().FirstOrDefault();

                var studentBook = new StudentBook();

                studentBook.Student = student;   //pahila foreign key wala data delete garna parxa ani balla primary data
                studentBook.Book = book;
                _context.StudentBooks.Remove(studentBook);
                _context.SaveChanges();

                TempData["success"] = "Book Returned Successfully";
                return RedirectToAction("Button", "Home");
            }
            return View(issue);

        }

        public IActionResult Manage_Students()
        {

            IEnumerable<Student> stud = _context.Students;
            return View(stud);

        }
        public IActionResult Add_Student()
        {
            return View();


        }
        [HttpPost]
        public IActionResult Add_Student(Student std)
        {
            if (!ModelState.IsValid)
            {
                _context.Students.Add(std);
                _context.SaveChanges();
                TempData["success"] = "Student Added Successfully";
                return RedirectToAction("Manage_Book", "Admin");
            }
            return View(std);

        }
        public IActionResult Edit_Students(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            return View(student);

        }
        [HttpPost]
        public IActionResult Edit_Students(StudentDto student)
        {
            var mapper = _mapper.Map<Student>(student);
            if (mapper.StudentId == null || mapper.StudentId == 0)
                return NotFound();
            var student1 = _context.Students.Find(mapper.StudentId);
            if (mapper == null)
                return NotFound();
            _context.Students.Remove(student1);
            _context.SaveChanges();
            TempData["success"] = "Student Edited Successfully";
            return RedirectToAction("Manage_Students");


        }


        public IActionResult View_Students()
        {
            IEnumerable<StudentBook> studentBooks = _context.StudentBooks;
            var issueBookDtos = _mapper.Map<IEnumerable<StudentBook>, IEnumerable<IssueBookDto>>(studentBooks);

            return View(issueBookDtos);

        }
        public IActionResult Issue_Request()
        {
            IEnumerable<Book> objUser = _context.Books;



            return View(objUser);

        }
        public IActionResult Manage_User()
        {
            IEnumerable<User> objUser = _context.Users;



            return View(objUser);

        }
        public IActionResult Add_User()
        {
            return View();

        }
        [HttpPost]
		//original wala
		//    public IActionResult Add_User(UserDto user)
		//    {
		//        var user1=_mapper.Map<User>(user);
		//        var student = _mapper.Map<Student>(user);



		//        if (ModelState.IsValid)
		//        {

		//            _context.Users.Add(user1);
		//_context.SaveChanges();
		//            var user2 = _context.Users.Find(user1.UserId);
		//            student.User= user2;
		//            _context.Students.Add(student);
		//            _context.SaveChanges();



		//            return RedirectToAction("Manage_User", "Admin");
		//        }
		//        return View(user1);

		//    }
		//identity wala
		public async Task<IActionResult>Add_User(UserDto usr)
        {
            var user1 = _mapper.Map<User>(usr);
            var student = _mapper.Map<Student>(usr);


		
			if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = user1.Username };
             var result= await _userManager.CreateAsync(user,user1.Password);

                if (!result.Succeeded) {
                await _signInManager.SignInAsync(user,isPersistent:false);
                    TempData["success"] = "User Added Successfully";

                    return RedirectToAction("Manage_User", "Admin");

				}
			
              



            }
            return View(usr);

        }

        public IActionResult Delete_User(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var UserFromDb = _context.Users.Find(id);
            if (UserFromDb == null)
            {
                return NotFound();

            }
            return View(UserFromDb);
        }
    
        [HttpPost]
        public IActionResult DeleteUser(User user)
        {
            if (user.UserId == null || user.UserId == 0)
                return NotFound();
            var book1 = _context.Users.Find(user.UserId);
            if (user == null)
                return NotFound();
            _context.Users.Remove(book1);
            _context.SaveChanges();
            TempData["success"] = "User Deleted Successfully";

            return RedirectToAction("Manage_User");

        }
        public IActionResult Edit_User(int? id)
        {
            if (id == null || id == 0)
                return NotFound();
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();

            return View(user);

        }
        [HttpPost]
        public IActionResult EditUser(User user)
        {
            if (!ModelState.IsValid)
            {
                _context.Update(user);
                _context.SaveChanges();
                TempData["success"] = "User Edited Successfully";


                return RedirectToAction("Manage_User");
            }
            return NotFound();
        }
    }
}




//from another
//namespace BulkyBookWeb.Controllers
//{
//	public class CategoryController : Controller
//	{
//		private readonly ApplicationDbContext _db;
//		//   [ActivatorUtilitiesConstructor]
//		public CategoryController(ApplicationDbContext db)
//		{
//			_db = db;
//		}
//		public IActionResult Index()
//		{
//			IEnumerable<Category> objCategoryList = _db.Categories;

//			return View(objCategoryList);
//		}
//		//GET action method
//		public IActionResult Create()
//		{
//			return View();
//		}
//		//POST 
//		[HttpPost]
//		[ValidateAntiForgeryToken]//helps from csx attack
//		public IActionResult Create(Category obj)
//		{
//			if (obj.Name == obj.DisplayOrder.ToString())
//			{
//				ModelState.AddModelError("name", "The Display Order Cannot Exactly Match The Name");
//			}
//			if (ModelState.IsValid)
//			{
//				_db.Categories.Add(obj);
//				_db.SaveChanges();
//				TempData["success"] = "Category Created Successfully";
//				return RedirectToAction("Index");
//			}
//			return View(obj);
//		}
//		//GET action method
//		public IActionResult Edit(int? id)
//		{
//			if (id == null || id == 0)
//			{
//				return NotFound();
//			}
//			var categoryFromDb = _db.Categories.Find(id);
//			if (categoryFromDb == null)
//			{
//				return NotFound();

//			}
//			return View(categoryFromDb);
//		}
//		//  POST 
//		[HttpPost]
//		[ValidateAntiForgeryToken]//helps from csx attack
//								  //   [ValidateAntiForgeryToken,HttpPost] this can also be written in one line 
//		public IActionResult Edit(Category obj)
//		{
//			if (obj.Name == obj.DisplayOrder.ToString())
//			{
//				ModelState.AddModelError("name", "The Display Order Cannot Exactly Match The Name");
//			}
//			if (ModelState.IsValid)
//			{
//				_db.Categories.Update(obj);
//				_db.SaveChanges();
//				TempData["success"] = "Category Edited Successfully";

//				return RedirectToAction("Index");
//			}
//			return View(obj);
//		}
//		//GET action method for delete
//		public IActionResult Delete(int? id)
//		{
//			if (id == null || id == 0)
//			{
//				return NotFound();
//			}
//			var categoryFromDb = _db.Categories.Find(id);
//			if (categoryFromDb == null)
//			{
//				return NotFound();

//			}
//			return View(categoryFromDb);
//		}
//		//  POST 

//		[ValidateAntiForgeryToken, HttpPost, ActionName("DeletePost")]//helps from csx attack
//		public IActionResult DeletePost(int? id)
//		{
//			var obj = _db.Categories.Find(id);
//			if (obj == null)
//			{
//				return NotFound();
//			}
//			_db.Categories.Remove(obj);
//			_db.SaveChanges();
//			TempData["success"] = "Category Deleted Successfully";

//			return RedirectToAction("Index");

//		}
//	}
//}









