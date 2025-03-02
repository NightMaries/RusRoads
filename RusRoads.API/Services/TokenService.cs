using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;

namespace RusRoads.API.Services
{
    public class TokenService(IConfiguration configuration)
    {
        private SymmetricSecurityKey _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]!));

        public string CreateToken(string name)
        {
            var claim = new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Name, name)
            };
            var creds = new SigningCredentials(_key,SecurityAlgorithms.HmacSha512Signature);

            var TokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claim),
                Expires= DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds

            };

            var TokenHandler = new JwtSecurityTokenHandler();
            var token = TokenHandler.CreateToken(TokenDescriptor);
            return TokenHandler.WriteToken(token);

        }
    }
}