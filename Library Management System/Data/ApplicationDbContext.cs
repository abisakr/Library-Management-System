using Library_Management_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) 
        {
            
        }
        public DbSet<Book>Books { get; set; }   
        public DbSet<Student>Students { get; set; }   
        public DbSet<User>Users { get; set; }
		public DbSet<StudentBook> StudentBooks { get; set; }

        public DbSet<Admin>tbl_admin { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Configure many-to - many relationship
        //            modelBuilder.Entity<MainEntity>()
        //        .HasMany(e => e.JoinEntities)
        //        .WithRequired(e => e.MainEntity)
        //        .HasForeignKey(e => e.MainEntityId)
        //        .WillCascadeOnDelete(false); // Prevents cascade deletion

        //    base.OnModelCreating(modelBuilder);
        //}

    }
}
