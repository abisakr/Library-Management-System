using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Repositories.UserApp
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Book> AvailableBooks()
        {
            var result = _dbContext.BookTbl.ToList();
            return result;
        }

        public IEnumerable<StudentBook> MyBooks(string user)
        {
            var userId = Convert.ToInt32(user);
            var books = _dbContext.StudentBookTbl.Include(a => a.Book).Where(a => a.StudentId == userId).ToList();
            return books;
        }
    }
}
