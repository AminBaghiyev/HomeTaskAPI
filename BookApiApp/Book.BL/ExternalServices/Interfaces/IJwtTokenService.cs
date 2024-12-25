using Book.Core.Entities;

namespace Book.BL.ExternalServices.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(AppUser appUser, string role);
}
