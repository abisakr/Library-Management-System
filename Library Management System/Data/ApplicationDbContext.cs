using Library_Management_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Book> BookTbl { get; set; }
        public DbSet<Student> StudentTbl { get; set; }
        public DbSet<User> UserTbl { get; set; }
        public DbSet<StudentBook> StudentBookTbl { get; set; }
        public DbSet<Admin> AdminTbl { get; set; }
    }
}
