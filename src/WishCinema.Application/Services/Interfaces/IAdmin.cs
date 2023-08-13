using DamnSmallMapper;
using Microsoft.EntityFrameworkCore;
using WishCinema.Application.Requests.Test;
using WishCinema.Application.Result;
using WishCinema.Application.Results;
namespace WishCinema.Application.Services.Interfaces
{
    public interface IAdmin
    {
        public Task<Result<string>> AddHall(AddHallRequest request);
        public Task<Result<string>> AddSession(AddSessionRequest request);
        public Task<Result<string>> AddMovie(AddMovieRequest request);
        public Task<Result<string>> AddCinema(AddCinemaRequest request);
        public Task<Result<string>> AddProduct(AddProductRequest request);
        public Task<Result<string>> AddGenre(string title);
        public Task<Result<string>> AddGenreToMovie(AddGenreToMovieRequest request);
    }
}