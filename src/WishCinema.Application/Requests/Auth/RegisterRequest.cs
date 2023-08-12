using WishCinema.Application.Requests.Base;
using WishCinema.Application.Services;

namespace WishCinema.Application.Requests.Auth
{
    public class RegisterRequest : BaseRequest
    {
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
