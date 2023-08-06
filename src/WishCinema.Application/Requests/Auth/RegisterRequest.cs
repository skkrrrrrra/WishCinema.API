using WishCinema.Application.Services;

namespace WishCinema.Application.Requests.Auth
{
    public class RegisterRequest
    {
        public string Username { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public DateTime CreatedAt { get; private set; } = DateHelper.GetCurrentDateTime();
        public DateTime UpdatedAt { get; private set; } = DateHelper.GetCurrentDateTime();
        public DateTime? DeletedAt { get; private set; } = null;
    }
}
