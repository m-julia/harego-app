using Data;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Security.Claims;


namespace API.Services
{
    public class TokenService
    {
        public string CreateToken(Member member)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, member.LastName),
                new Claim(ClaimTypes.Name, member.FirstName),
                new Claim(ClaimTypes.MobilePhone, member.PhoneNumber)
            };

        }
    }
}
