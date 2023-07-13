using AutoMapper;
using Library_Management_System.DTO;
using Library_Management_System.Models;

namespace Library_Management_System.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto,Student>().ReverseMap();
            CreateMap<IssueBookDto, Student>().ReverseMap();
            CreateMap<IssueBookDto, Book>().ReverseMap();
            CreateMap<ReturnDto, Book>().ReverseMap();
            CreateMap<ReturnDto, Student>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
        }
    }
}
