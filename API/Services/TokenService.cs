using Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
    public class TokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string CreateToken(Member member)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, member.Id.ToString()),
                new Claim(ClaimTypes.Name, member.LastName),
                new Claim(ClaimTypes.Name, member.FirstName),
                new Claim(ClaimTypes.MobilePhone, member.PhoneNumber)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
