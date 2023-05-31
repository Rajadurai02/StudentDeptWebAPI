using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentDeptWebAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StudentDeptWebAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _Userkey;

        public TokenService(IConfiguration configuration)
        {
            _Userkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }
        public string CreateUserToken(UserDTO userDTO)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,userDTO.Email)
            };
            var cred = new SigningCredentials(_Userkey, SecurityAlgorithms.HmacSha256Signature);
            var tokendesc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = cred
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokendesc);
            return tokenHandler.WriteToken(token);
        }
    }
}
