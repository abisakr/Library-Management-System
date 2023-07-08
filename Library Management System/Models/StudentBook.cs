using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_System.Models
{
	public class StudentBook
	{
		[Key]
		public int StudentBookId { get; set; }
		
		[ForeignKey("Student")]
		public int StudentId { get; set; }
		public Student Student { get; set; }

		[ForeignKey("Book")]
		public int BookId { get; set; }
		public Book Book { get; set; }
		

    }
}
