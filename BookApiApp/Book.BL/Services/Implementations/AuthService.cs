using AutoMapper;
using Book.BL.DTOs.AppUserDtos;
using Book.BL.Exceptions.CommonExceptions;
using Book.BL.ExternalServices.Interfaces;
using Book.BL.Services.Abstractions;
using Book.Core.Entities;
using Book.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Book.BL.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IMapper _mapper;

    public AuthService(UserManager<AppUser> userManager, IMapper mapper, 
        IJwtTokenService jwtTokenService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<string> LoginAsync(AppUserLoginDto entityLoginDto)
    {
        AppUser?  existingUser = await _userManager.FindByNameAsync(entityLoginDto.UserName);
        if (existingUser == null) { throw new EntityNotFoundException(); }
        bool result = await _userManager.CheckPasswordAsync(existingUser, entityLoginDto.Password);
        if (!result) {throw new Exception("Username or password is wrong"); }

        IEnumerable<string> roles = await _userManager.GetRolesAsync(existingUser);
        string role = roles.FirstOrDefault() ?? UserRoles.User.ToString();
        string token = _jwtTokenService.GenerateToken(existingUser, role);

        return token;
    }

    public async Task<bool> RegisterAsync(AppUserCreateDto entityCreateDto)
    {
        AppUser user = _mapper.Map<AppUser>(entityCreateDto);
        var result = await _userManager.CreateAsync(user, entityCreateDto.Password);
        if (!result.Succeeded)
        {
            throw new Exception("Could not create user");
        }
        await _userManager.AddToRoleAsync(user, UserRoles.User.ToString());
        return true;
    }
}
