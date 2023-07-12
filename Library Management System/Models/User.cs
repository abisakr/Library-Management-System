using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_System.Models
{
    public class User {

        [Key]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string Username { get; set; }
        [Required]

        [DataType(DataType.Password)]

        public string Password { get; set; }
	

		[InverseProperty("User")]
		public Student Student { get; set; }
       


    }
}
