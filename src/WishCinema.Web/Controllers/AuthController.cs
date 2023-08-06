using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WishCinema.Application.Requests.Auth;
using WishCinema.Application.Responses.Auth;
using WishCinema.Application.Result;
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
        public async Task<Result<bool>> Register([FromBody] RegisterRequest request)
        {
            var result = await _userManager.RegisterAsync(request);
            return result;
        }

        [HttpPost]
        [Route("login")]
        public async Task<Result<LoginResponse>> Login([FromBody] LoginRequest request)
        {
            var result = await _userManager.LoginWithPassword(request);
            return result;
        }
    }
}
