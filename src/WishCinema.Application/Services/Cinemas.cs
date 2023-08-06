using Microsoft.EntityFrameworkCore;
using WishCinema.Application.Models;
using WishCinema.Application.Result;
using WishCinema.Application.Results;
using WishCinema.Application.Services.Interfaces;
using WishCinema.Persistence;

namespace WishCinema.Application.Services
{
    public class Cinemas : ICinemas
    {
        private readonly MainDbContext _dbContext;
        public Cinemas(MainDbContext dbContext)
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
                .Where(
                    item => item.CinemaId == cinema.Id
                    && item.StartDate > DateHelper.GetCurrentDateTime())
                .Select(item => new SessionModel(item))
                .ToListAsync();

            return new SuccessResult<IEnumerable<SessionModel>>(sessions);
        }
    }
}
