using ICut.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ICut.Domain.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken()
        {
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.Name, "teste"),
                    new Claim(ClaimTypes.Email, "teste@gmail.com"),
                    new Claim(ClaimTypes.Role, "admin")
                }),

                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey
                    (Encoding.ASCII.GetBytes(_configuration["secretKey"])),
                     SecurityAlgorithms.HmacSha256Signature),
                Audience = _configuration["Audience"],
                Issuer = _configuration["Issuer"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
