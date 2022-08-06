using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProvaSuficienciaWebII.Handler.Auth;
using ProvaSuficienciaWebII.Models.Auth;

namespace ProvaSuficienciaWebII.Controllers
{
    [ApiController]
    [Route("[controller]")]

    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthHandler _handler;

        public AuthController(IAuthHandler handler)
        {
            _handler= handler;
        }

        [HttpGet]
        [Route("auth")]
        public AuthViewModel Autenticar()
        {
            var (token, expiration) = _handler.GerarAuth();

            return new AuthViewModel
            {
                Token = token,
                DataExpiracao = expiration,
            };
        }
    }
}
