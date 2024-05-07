using AutoMapper;
using Library_Management_System.Data;
using Library_Management_System.DTO;
using Library_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Repositories.AdminApp
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AdminRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<StudentBook> BooksTaken()
        {
            var result = _dbContext.StudentBookTbl.Include(a => a.Book)
                   .Include(a => a.Student);
            return result;
        }

        public void AddBook(BookDto book)
        {
            var result = _mapper.Map<Book>(book);
            _dbContext.BookTbl.Add(result);
            _dbContext.SaveChanges();
        }

        public void AddUser(UserDto user)
        {
            var userView = _mapper.Map<User>(user);
            var student = _mapper.Map<Student>(user);
            _dbContext.UserTbl.Add(userView);
            _dbContext.SaveChanges();
            var user2 = _dbContext.UserTbl.Find(userView.UserId);
            student.User = user2;
            _dbContext.StudentTbl.Add(student);
            _dbContext.SaveChanges();
        }

        public bool DeleteBook(Book book)
        {
            var result = _dbContext.BookTbl.FirstOrDefault(a => a.BookId == book.BookId);
            if (result != null)
            {
                _dbContext.BookTbl.Remove(result);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public void EditBook(BookDto book)
        {
            var results = _mapper.Map<Book>(book);
            _dbContext.Update(results);
            _dbContext.SaveChanges();
        }

        public void EditStudent(StudentDto student)
        {
            var mapper = _mapper.Map<Student>(student);
            _dbContext.Update(mapper);
            _dbContext.SaveChanges();
        }

        public void EditUser(User user)
        {
            _dbContext.Update(user);
            _dbContext.SaveChanges();
        }

        public Book FindBookById(int? id)
        {
            var result = _dbContext.BookTbl.Find(id);
            return result;
        }

        public Student FindStudentById(int? id)
        {
            var result = _dbContext.StudentTbl.FirstOrDefault(a => a.StudentId == id);
            return result;
        }

        public IEnumerable<StudentDto> GetAllStudents()
        {
            var students = _dbContext.StudentTbl.ToList();
            var result = _mapper.Map<List<StudentDto>>(students);
            return result;
        }

        public IEnumerable<User> GetAllUsers()
        {
            var result = _dbContext.UserTbl.ToList();
            return result;
        }

        public void IssueBook(IssueBookDto issue)
        {
            var book = _dbContext.BookTbl.Where(x => x.BookId == issue.BookId).ToList().FirstOrDefault();
            var student = _dbContext.StudentTbl.Where(x => x.StudentId == issue.StudentId).ToList().FirstOrDefault();
            var studentBook = new StudentBook();
            studentBook.Student = student;
            studentBook.Book = book;

            _dbContext.StudentBookTbl.Add(studentBook);
            _dbContext.SaveChanges();
            var book1 = _dbContext.BookTbl.Where(x => x.BookId == issue.BookId).ToList().FirstOrDefault();
            book1.NoOfBooks--;

            _dbContext.Update(book1);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            var result = _dbContext.BookTbl.ToList();
            return result;
        }

        public void Return(IssueBookDto issueBook)
        {
            StudentBook students = _dbContext.StudentBookTbl.Where(a => a.StudentId == issueBook.StudentId && a.BookId == issueBook.BookId).ToList().FirstOrDefault();
            _dbContext.StudentBookTbl.Remove(students);
            _dbContext.SaveChanges();
            var book1 = _dbContext.BookTbl.Where(x => x.BookId == issueBook.BookId).ToList().FirstOrDefault();
            book1.NoOfBooks++;
            _dbContext.Update(book1);
            _dbContext.SaveChanges();
        }

        public User FindUserById(int? id)
        {
            var result = _dbContext.UserTbl.Find(id);
            return result;
        }

        public void DeleteUser(User user)
        {
            _dbContext.UserTbl.Remove(user);
            _dbContext.SaveChanges();
        }
    }
}
