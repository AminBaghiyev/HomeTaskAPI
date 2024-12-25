using EmployeeManagement.BL.ExternalServices.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeManagement.BL.ExternalServices.Implementations;

public class JWTTokenService : IJWTTokenService
{
    readonly IConfiguration _configuration;

    public JWTTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(IEnumerable<Claim> payload)
    {
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(GetSecretKey()));
        SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new(
            issuer: GetIssuer(),
            audience: GetAudience(),
            claims: payload,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GetAudience() => _configuration["JWT:Audience"] ?? throw new Exception("Audience not found!");

    public string GetIssuer() => _configuration["JWT:Issuer"] ?? throw new Exception("Issuer not found!");

    public string GetSecretKey() => _configuration["JWT:SecretKey"] ?? throw new Exception("Secret key not found!");
}
