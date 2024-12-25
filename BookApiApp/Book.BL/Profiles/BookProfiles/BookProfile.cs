using AutoMapper;
using Book.BL.DTOs.BookDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BL.Profiles.BookProfiles
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            
            CreateMap<BookCreateDto, Core.Entities.Book>().ReverseMap();
            CreateMap<BookEditDto, Core.Entities.Book>().ReverseMap().
            ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            


        }
    }
}
