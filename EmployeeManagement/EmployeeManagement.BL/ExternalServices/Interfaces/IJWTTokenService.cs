using System.Security.Claims;

namespace EmployeeManagement.BL.ExternalServices.Interfaces;

public interface IJWTTokenService
{
    string GenerateToken(IEnumerable<Claim> payload);
    string GetSecretKey();
    string GetIssuer();
    string GetAudience();
}
