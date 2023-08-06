using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WishCinema.Application.Requests;
using WishCinema.Application.Services.Interfaces;

namespace WishCinema.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserManager _userManager;
        public AuthController(IUserManager userManager)
        {
            _userManager = userManager; 
        }

        [HttpPost]
        [Route("register")]
        public async Task<bool> Register([FromBody] RegisterRequest request)
        {
            var result = await _userManager.RegisterAsync(request);
            return result;
        }

        [HttpPost]
        [Route("login")]
        public async Task<string> Login([FromBody] LoginRequest request)
        {
            var result = await _userManager.LoginWithPassword(request);
            return result;
        }
    }
}
