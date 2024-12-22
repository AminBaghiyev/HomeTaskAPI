using EmployeeManagement.BL.DTOs;
using EmployeeManagement.Core.Entities;

namespace EmployeeManagement.BL.Services.Implementations;

public interface IAccountService
{
    Task RegisterAsync(CreateUserDto dto);
    Task<bool> ConfirmEmailAsync(string userId, string token);
    Task<bool> ChangePasswordAsync(ChangePasswordDto dto);
    Task<List<ListUserDto>> GetAllUsers();
    Task<AppUser> GetOneUser(string email);
}
