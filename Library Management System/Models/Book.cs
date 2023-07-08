using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_System.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Auther { get; set; }
        public string BFaculty { get; set; }
		public int? NoOfBooks { get; set; }
		public ICollection<StudentBook> StudentBooks { get; set; }


	}
}
