using AutoMapper;
using SchoolUser.Application.DTOs;
using SchoolUser.Domain.Models;

namespace SchoolUser.Domain.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, AddUserRequestDto>().ReverseMap();
        CreateMap<User, AddUserResponseDto>().ReverseMap();
        CreateMap<User, LoginResponseDto>().ReverseMap();
        CreateMap<User, GetUserRequestDto>().ReverseMap();

        CreateMap<User, GetUserResponseDto>()
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.BirthDate))
            .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles ?? new List<string>()))
            .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Student))
            .ForMember(dest => dest.Teacher, opt => opt.MapFrom(src => src.Teacher));

        CreateMap<Student, StudentResponseDto>();
        CreateMap<Teacher, TeacherResponseDto>();

        CreateMap<Student, GetUserRequestDto>().ReverseMap();
        CreateMap<Teacher, GetUserRequestDto>().ReverseMap();
    }
}
