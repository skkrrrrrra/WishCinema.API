using WishCinema.Application.Requests.Base;

namespace WishCinema.Application.Requests.Auth
{
    public class LoginRequest : BaseRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
