using WishCinema.Application.Requests.Auth;
using WishCinema.Application.Responses.Auth;
using WishCinema.Application.Result;

namespace WishCinema.Application.Services.Interfaces
{
    public interface IUserManagerService
    {
        public Task<Result<string>> RegisterAsync(RegisterRequest request);
        public Task<Result<LoginResponse>> LoginWithPassword(LoginRequest request);

    }
}
