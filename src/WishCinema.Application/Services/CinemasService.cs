using Microsoft.EntityFrameworkCore;
using WishCinema.Application.Responses;
using WishCinema.Application.Result;
using WishCinema.Application.Results;
using WishCinema.Application.Services.Interfaces;
using WishCinema.Persistence;

namespace WishCinema.Application.Services
{
    public class CinemasService : ICinemasService
    {
        private readonly MainDbContext _dbContext;
        public CinemasService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<IEnumerable<CinemaModel>>> GetCinemasList()
        {
            var cinemas = await _dbContext.Cinemas
                .Where(item => item.DeletedAt == null)
                .Select(item => new CinemaModel(item))
                .ToListAsync();

            return new SuccessResult<IEnumerable<CinemaModel>>(cinemas);
        }

        public async Task<Result<IEnumerable<SessionModel>>> GetSessionsByCinema(string cinemaTitle)
        {
            var cinema = await _dbContext.Cinemas
                .FirstOrDefaultAsync(item => item.Title == cinemaTitle);
            
            if(cinema == null)
            {
                return new InvalidResult<IEnumerable<SessionModel>>("cinema_does_not_exist");
            }
            
            var sessions = await _dbContext.Sessions
                .Include(session => session.Movie)
                .Where(
                    item => item.CinemaId == cinema.Id
                    && item.StartDate > DateHelper.GetCurrentDateTime())
                .Select(session => new SessionModel(session))
                .ToListAsync();

            return new SuccessResult<IEnumerable<SessionModel>>(sessions);
        }


        public async Task<Result<SessionModel>> GetSessionInfo(string cinemaTitle, int sessionId)
        {
            var cinema = await _dbContext.Cinemas
                .FirstOrDefaultAsync(item => item.Title == cinemaTitle);

            if (cinema == null)
            {
                return new InvalidResult<SessionModel>("cinema_does_not_exist");
            }


            var session = await _dbContext.Sessions
                .Include(session => session.Movie)
                .FirstOrDefaultAsync(item => item.Id == sessionId);

            if(session == null)
            {
                return new InvalidResult<SessionModel>("session_does_not_exist");
            }

            var response = new SessionModel(session);

            return new SuccessResult<SessionModel>(response);
        }
    }
}
