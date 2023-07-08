using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_System.Models
{
    public class Student {

        [Key]
        public int StudentId { get; set; }
    public string StudentName { get; set; }
    public string Address { get; set; }
    public string Faculty { get; set; }
        public int? NoOfBooksTaken { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        [ForeignKey("User")]
		public int UserId { get; set; }
		public User User { get; set; }
		public ICollection<StudentBook> StudentBooks { get; set; }

	}
}
