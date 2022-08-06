using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ProvaSuficienciaWebII.Handler.Auth
{
    public class AuthHandler : IAuthHandler
    {
        private readonly IConfiguration _configuration;

        public AuthHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public (string, DateTime) GerarAuth()
        {
            var dataExpiracao = DateTime.UtcNow.AddHours(4);

            var secret = _configuration["JWT:Key"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: null,
                expires: dataExpiracao,
                signingCredentials: credentials);

            return (new JwtSecurityTokenHandler().WriteToken(token), dataExpiracao);
        }

    }
}
