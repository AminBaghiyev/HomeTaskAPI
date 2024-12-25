using Book.BL.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.BL.Services.Abstractions
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(AppUserCreateDto entityCreateDto);
        Task<string> LoginAsync(AppUserLoginDto entityLoginDto);
    }
}
