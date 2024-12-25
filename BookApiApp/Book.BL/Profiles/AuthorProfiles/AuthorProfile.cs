using AutoMapper;
using Book.BL.DTOs.AuthorDtos;
using Book.Core.Entities;

namespace Book.BL.Profiles.AuthorProfiles;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<AuthorCreateDto, Author>().ReverseMap();
        CreateMap<AuthorListItemDto, Author>().ReverseMap();
    }
}
