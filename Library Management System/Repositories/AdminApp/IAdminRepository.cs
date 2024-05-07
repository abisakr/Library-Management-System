using Library_Management_System.DTO;
using Library_Management_System.Models;

namespace Library_Management_System.Repositories.AdminApp
{
    public interface IAdminRepository
    {
        public IEnumerable<Book> GetAllBooks();
        public void AddBook(BookDto book);
        public Book FindBookById(int? id);
        public void EditBook(BookDto book);
        public void IssueBook(IssueBookDto issue);
        public IEnumerable<StudentDto> GetAllStudents();
        public void EditStudent(StudentDto student);
        public IEnumerable<User> GetAllUsers();
        public void AddUser(UserDto user);
        public IEnumerable<StudentBook> BooksTaken();
        public Student FindStudentById(int? id);
        public User FindUserById(int? id);
        public void EditUser(User user);
        public void Return(IssueBookDto issueBookDto);
        public void DeleteUser(User user);
        public bool DeleteBook(Book book);
    }
}
