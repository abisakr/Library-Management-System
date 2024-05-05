using AutoMapper;
using Library_Management_System.DTO;
using Library_Management_System.Models;

namespace Library_Management_System.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            this.CreateMap<User, UserDto>().ReverseMap();
            this.CreateMap<UserDto, Student>().ReverseMap();
            this.CreateMap<IssueBookDto, Student>().ReverseMap();
            this.CreateMap<IssueBookDto, Book>().ReverseMap();
            this.CreateMap<ReturnDto, Book>().ReverseMap();
            this.CreateMap<ReturnDto, Student>().ReverseMap();
            this.CreateMap<Student, StudentDto>().ReverseMap();
            this.CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
