using DamnSmallMapper;
using Microsoft.EntityFrameworkCore;
using WishCinema.Application.Requests.Test;
using WishCinema.Application.Result;
using WishCinema.Application.Results;
using WishCinema.Domain.Entities;
using WishCinema.Persistence;

namespace WishCinema.Application.Services
{
    public class ForTestService
    {
        private readonly MainDbContext _dbContext;
        public ForTestService(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<string>> AddCinema(AddCinemaRequest request)
        {
            var tryToSearchCinema = await _dbContext.Cinemas
                .FirstOrDefaultAsync(cinema => cinema.Address == request.Address && cinema.Title == request.Title);

            if (tryToSearchCinema != null)
            {
                return new InvalidResult<string>("CINEMA_ALREADY_EXIST");
            }

            var cinema = Mapper.Map<Cinema>(request);

            await _dbContext.Cinemas.AddAsync(cinema);
            await _dbContext.SaveChangesAsync();
            return new SuccessResult<string>("SUCCESS");
        }

        public async Task<Result<string>> AddMovie(AddMovieRequest request)
        {
            var tryToSearchMovie = await _dbContext.Movies
                .FirstOrDefaultAsync(movie => movie.Title == request.Title);

            if(tryToSearchMovie != null)
            {
                return new InvalidResult<string>("MOVIE_ALREADY_EXIST");
            }

            var movie = Mapper.Map<Movie>(request);

            await _dbContext.Movies.AddAsync(movie);
            await _dbContext.SaveChangesAsync();
            return new SuccessResult<string>("SUCCESS");
        }

        public async Task<Result<string>> AddSession(AddSessionRequest request)
        {
            var tryToSearchSession = await _dbContext.Sessions
                .FirstOrDefaultAsync(
                    session => session.HallId == request.HallId
                    && session.CinemaId == request.CinemaId
                    && 
                    (
                        session.StartDate >= request.StartDate.AddMinutes(-15) 
                        && session.EndDate <= request.EndDate.AddMinutes(15)
                    )
                );

            if(tryToSearchSession != null)
            {
                return new InvalidResult<string>("SESSION_ON_THIS_TIME_ALREADY_EXIST");
            }

            var session = Mapper.Map<Session>(request);

            await _dbContext.Sessions.AddAsync(session);
            await _dbContext.SaveChangesAsync();
            return new SuccessResult<string>("SUCCESS");
        }

        public async Task<Result<string>> AddHall(AddHallRequest request)
        {
            var tryToSearchHall = await _dbContext.Halls
                .FirstOrDefaultAsync(hall => hall.CinemaId == request.CinemaId && hall.Title == request.Title);

            if (tryToSearchHall != null)
            {
                return new InvalidResult<string>("HALL_ALREADY_EXIST");
            }

            var hall = Mapper.Map<Hall>(request);

            await _dbContext.Halls.AddAsync(hall);
            await _dbContext.SaveChangesAsync();
            return new SuccessResult<string>("SUCCESS");
        }
    }
}
