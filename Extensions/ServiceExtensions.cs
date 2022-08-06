using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.Text;

namespace ProvaSuficienciaWebII.Extensions
{
    public static class ServiceExtensions
    {
        #region Autenticacao
        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var secret = configuration["JWT:Key"];
            var key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

            .AddJwtBearer(x =>
            {

                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero

                };
            });

            return services;
        }

        #endregion
    }
}
