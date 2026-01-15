using Microsoft.Extensions.Configuration;
using MyDoc.Application.BO.DTO.User;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace MyDoc.Application.Helper
{
    internal class JwtHelper
    {
        private readonly IConfiguration _config;

        public JwtHelper(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(UserAuthDTO user)
        {
            var jwtSettings = _config.GetSection("Jwt");
            var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim("applicationId", user.ApplicationId.ToString()),
                new Claim("applicationName", user.ApplicationName),
                new Claim("email", user.Email),
                new Claim("roleId", user.RoleId.ToString()),
                new Claim("roleName", user.RoleName),
                new Claim("applicationId", user.ApplicationId.ToString()),
                new Claim("applicationName", user.ApplicationName)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["Key"])
            );
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    int.Parse(jwtSettings["ExpiresMinutes"])
                ),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
