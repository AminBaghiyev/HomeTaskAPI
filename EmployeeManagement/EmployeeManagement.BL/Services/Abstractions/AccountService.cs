﻿using AutoMapper;
using EmployeeManagement.BL.DTOs;
using EmployeeManagement.BL.Services.Implementations;
using EmployeeManagement.Core.Entities;
using Microsoft.AspNetCore.Identity;
using EmployeeManagement.BL.Exceptions;
using EmployeeManagement.BL.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.BL.Services.Abstractions;

public class AccountService : IAccountService
{
    readonly IHttpContextAccessor _httpContextAccessor;
    readonly EmailService _emailService;
    readonly UserManager<AppUser> _userManager;
    readonly IMapper _mapper;

    public AccountService(IMapper mapper, UserManager<AppUser> userManager, EmailService emailService, IHttpContextAccessor httpContextAccessor)
    {
        _mapper = mapper;
        _userManager = userManager;
        _emailService = emailService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> ChangePasswordAsync(ChangePasswordDto dto)
    {
        AppUser user = await _userManager.FindByEmailAsync(dto.Email) ?? throw new EntityNotFoundException();

        IdentityResult result = await _userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);
        if (!result.Succeeded)
            throw new UserPasswordCouldNotBeChangedException();

        return true;
    }

    public async Task<bool> ConfirmEmailAsync(string userId, string token)
    {
        AppUser user = await _userManager.FindByIdAsync(userId) ?? throw new EntityNotFoundException();

        IdentityResult result = await _userManager.ConfirmEmailAsync(user, token);
        if (!result.Succeeded)
            throw new UserEmailCouldNotBeVerifiedException();

        return true;
    }

    public async Task<List<ListUserDto>> GetAllUsers()
    {
        return _mapper.Map<List<ListUserDto>>(
            await _userManager.Users.ToListAsync()
        );
    }

    public async Task<AppUser> GetOneUser(string email)
    {
        return await _userManager.FindByEmailAsync(email) ?? throw new EntityNotFoundException();
    }

    public async Task RegisterAsync(CreateUserDto dto)
    {
        AppUser user = _mapper.Map<AppUser>(dto);

        if (await _userManager.FindByEmailAsync(user.Email) is not null)
            throw new UserExistsException("User with this email already exists!");

        if (await _userManager.FindByNameAsync(user.UserName) is not null)
            throw new UserExistsException("User with this username already exists!");

        IdentityResult result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded) throw new UserCouldNotBeCreatedException();

        string userToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        HttpRequest request = _httpContextAccessor.HttpContext.Request;
        string baseUrl = $"{request.Scheme}://{request.Host}";
        string confirmationUrl = $"{baseUrl}/accounts/ConfirmEmail?userId={user.Id}&token={userToken}";
        _emailService.SendConfirmation(user.Email, confirmationUrl);
    }
}