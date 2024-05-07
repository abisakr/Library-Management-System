using Library_Management_System.Models;

namespace Library_Management_System.Repositories.UserApp
{
    public interface IUserRepository
    {
        public IEnumerable<StudentBook> MyBooks(string user);
        public IEnumerable<Book> AvailableBooks();
    }
}
