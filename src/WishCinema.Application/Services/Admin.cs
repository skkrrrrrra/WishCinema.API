using DamnSmallMapper;
using Microsoft.EntityFrameworkCore;
using System;
using WishCinema.Application.Requests.Test;
using WishCinema.Application.Result;
using WishCinema.Application.Results;
using WishCinema.Application.Services.Interfaces;
using WishCinema.Domain.Entities;
using WishCinema.Persistence;

namespace WishCinema.Application.Services
{
    public class Admin : IAdmin
    {
        private readonly MainDbContext _dbContext;
        public Admin(MainDbContext dbContext)
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
            //создаем сеанс
            #region
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

            var result = await _dbContext.Sessions.AddAsync(session);
            await _dbContext.SaveChangesAsync();
            #endregion

            var hall = await _dbContext.Halls
                .FirstOrDefaultAsync(hall => hall.Id == request.HallId);

            var places = await _dbContext.Places
                .Where(place => place.HallId == hall.Id)
                .ToListAsync();

            var tickets = new List<Ticket>();
            var dateTime = DateHelper.GetCurrentDateTime();
            for (int i = 0; i < places.Count(); i++)
            {
                tickets.Add(new Ticket(places[i].Id, session.Id, 0, dateTime, dateTime, null));
            }

            await _dbContext.Tickets.AddRangeAsync(tickets);
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


            tryToSearchHall = await _dbContext.Halls
                .FirstOrDefaultAsync(hall => hall.CinemaId == request.CinemaId && hall.Title == request.Title);

            var places = new List<Place>();
            var dateTime = DateHelper.GetCurrentDateTime();
            for (int i = 0; i < request.CountOfPlaces; i++)
            {
                places.Add(new Place(tryToSearchHall.Id, dateTime, dateTime));
            }

            await _dbContext.Places.AddRangeAsync(places);
            await _dbContext.SaveChangesAsync();

            return new SuccessResult<string>("SUCCESS");
        }

        public async Task<Result<string>> AddProduct(AddProductRequest request)
        {
            var tryToSearchProduct = await _dbContext.Products
                .FirstOrDefaultAsync(product => product.Title == product.Title);

            if(tryToSearchProduct != null)
            {
                return new InvalidResult<string>("PRODUCT_ALREADY_EXIST");
            }

            var product = Mapper.Map<Product>(request);

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return new SuccessResult<string>("SUCCESS");
        }

        public async Task<Result<string>> AddGenre(string title)
        {
            var genre = await _dbContext.Genres
                .FirstOrDefaultAsync(genre => genre.Title == title);

            if (genre != null)
            {
                return new InvalidResult<string>("GENRE_ALREADY_EXIST");
            }

            var dateTime = DateHelper.GetCurrentDateTime();
            genre = new Genre(title, dateTime, dateTime, null);
            await _dbContext.Genres.AddAsync(genre);
            await _dbContext.SaveChangesAsync();

            return new SuccessResult<string>("SUCCESS");
        }

        public async Task<Result<string>> AddGenreToMovie(AddGenreToMovieRequest request)
        {
            var dateTime = DateHelper.GetCurrentDateTime();

            var tryToSearchGenreMovie = await _dbContext.GenresMovies
                .FirstOrDefaultAsync(genreMovie =>
                genreMovie.GenreId == request.GenreId
                && genreMovie.MovieId == request.MovieId);

            if(tryToSearchGenreMovie != null)
            {
                return new InvalidResult<string>("GENRE_TO_MOVIE_ALREADY_EXIST");
            }

            var genreMovie = new GenresMovie(request.GenreId, request.MovieId, dateTime, dateTime, null);

            await _dbContext.AddAsync(genreMovie);
            await _dbContext.SaveChangesAsync();
            return new SuccessResult<string>("SUCCESS");
        }
    }
}
