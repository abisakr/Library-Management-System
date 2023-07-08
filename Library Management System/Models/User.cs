using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_System.Models
{
    public class User {

        [Key]
        public int UserId { get; set; }
        
		public string Username { get; set; }
       
		public string Password { get; set; }
	

		[InverseProperty("User")]
		public Student Student { get; set; }
       


    }
}
