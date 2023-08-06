using WishCinema.Application.Requests;
namespace WishCinema.Application.Services.Interfaces
{
    public interface IUserManager
    {
        public Task<bool> RegisterAsync(RegisterRequest request);
        public Task<string> LoginWithPassword(LoginRequest request);

    }
}
