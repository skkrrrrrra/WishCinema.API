using WishCinema.Application.Responses;
using WishCinema.Application.Result;

namespace WishCinema.Application.Services.Interfaces
{
    public interface ICinemasService
    {
        public Task<Result<IEnumerable<SessionModel>>> GetSessionsByCinema(string cinemaTitle);
        public Task<Result<IEnumerable<CinemaModel>>> GetCinemasList();
        public Task<Result<SessionModel>> GetSessionInfo(string cinemaTitle, int sessionId);
    }
}