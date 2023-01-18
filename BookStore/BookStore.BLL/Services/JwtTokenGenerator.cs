using BookStore.BLL.Interfaces;
using BookStore.BLL.Models.Authentication;
using BookStore.DAL.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.BLL.Services
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtOptions _options;

        public JwtTokenGenerator(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public Task<string> GenerateAsync(User user , IEnumerable<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role,role));
            }
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.Key));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_options.Duration),
                Audience = _options.Audience,
                Issuer = _options.Issuer,
                SigningCredentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256Signature)
            };
            var handler = new JwtSecurityTokenHandler();
            var unSerializedToken = handler.CreateToken(tokenDescriptor);
            var token = handler.WriteToken(unSerializedToken);
            return  Task.FromResult(token);

        }
    }
}
