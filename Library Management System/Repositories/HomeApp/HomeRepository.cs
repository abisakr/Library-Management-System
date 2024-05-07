using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Repositories.Home
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public Admin Login(Admin admin)
        {
            var result = _dbContext.AdminTbl.Where(a => a.Username == admin.Username && a.Password == admin.Password).FirstOrDefault();
            return result;
        }

        public User UserLoginPage(User user)
        {
            var result = _dbContext.UserTbl.Include(a => a.Student).FirstOrDefault(a => a.Username == user.Username && a.Password == user.Password);
            return result;
        }
    }
}
