using Library_Management_System.Models;

namespace Library_Management_System.Repositories.Home
{
    public interface IHomeRepository
    {
        public User UserLoginPage(User user);
        public Admin Login(Admin admin);

    }
}
