using AutoMapper;
using EmployeeManagement.BL.DTOs;
using EmployeeManagement.Core.Entities;

namespace EmployeeManagement.BL.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, AppUser>().ReverseMap();
        CreateMap<AppUser, ListUserDto>();
    }
}
