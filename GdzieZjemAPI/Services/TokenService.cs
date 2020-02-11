using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using GdzieZjemAPI.Controllers;
using GdzieZjemAPI.Helpers;
using GdzieZjemAPI.Interfaces;
using GdzieZjemAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace GdzieZjemAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly ApiContext _apiContext;
        private readonly IConfiguration _configuration;

        public TokenService(ApiContext apiContext, IConfiguration configuration)
        {
            _apiContext = apiContext;
            _configuration = configuration;
        }

        public string GenerateToken(string username, string password)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                claims: new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                },
                notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                expires: new DateTimeOffset(DateTime.Now.AddMinutes(60)).DateTime,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}