namespace Library_Management_System.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string StudentName { get; set; }
        public string Address { get; set; }
        public string Faculty { get; set; }
        public int? NoOfBooksTaken { get; set; }
    }
}
