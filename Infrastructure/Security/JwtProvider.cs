
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using School_API.App.DTO;


namespace School_API.Infrastructure.Security
{
    public class JwtProvider
    {
        private readonly string? _key;
        private readonly string? _issuer;
        private readonly string? _audience;
        private readonly string? _expirationTime; // Minutes
    
        public JwtProvider(IConfiguration configuration)
        {
            _key = configuration["Jwt:Key"];
            _issuer = configuration["Jwt:Issuer"];
            _audience = configuration["Jwt:Audience"];
            _expirationTime = configuration["Jwt:ExpirationTime"];
        }

        public string GenerateSecurityToken(CreateJwtDTO createJwt)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: new List<Claim>
                {
                    new Claim("Id", createJwt.Id.ToString()),
                    // new Claim(ClaimTypes.Name, createJwt.Name),
                    // new Claim(ClaimTypes.Surname, createJwt.Surname),
                    new Claim(ClaimTypes.Role, createJwt.Role)
                },
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_expirationTime)),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}