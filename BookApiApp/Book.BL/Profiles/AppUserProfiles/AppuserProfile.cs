using AutoMapper;
using Book.BL.DTOs.AppUserDtos;
using Book.BL.DTOs.AuthorDtos;
using Book.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BL.Profiles.AppUserProfiles
{
    public class AppuserProfile: Profile
    {
        public AppuserProfile()
        {
            CreateMap<AppUserCreateDto, AppUser>();
           
        }
    }
}
