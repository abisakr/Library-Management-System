using Library_Management_System.Data;

namespace Library_Management_System.Repositories.Home
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
    }
}
