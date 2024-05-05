using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
