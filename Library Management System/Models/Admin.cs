using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
	public class Admin
	{
		[Key]
		public int AdminId { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
