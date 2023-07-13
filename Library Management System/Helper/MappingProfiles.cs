using AutoMapper;
using Library_Management_System.DTO;
using Library_Management_System.Models;

namespace Library_Management_System.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
          
            //for user

            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<UserDto,Student>().ReverseMap();
           



            //for student and book

            CreateMap<IssueBookDto, Student>().ReverseMap();
            CreateMap<IssueBookDto, Book>().ReverseMap();
            //for student and book
            CreateMap<ReturnDto, Book>().ReverseMap();
            CreateMap<ReturnDto, Student>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();

        }
    }
}
