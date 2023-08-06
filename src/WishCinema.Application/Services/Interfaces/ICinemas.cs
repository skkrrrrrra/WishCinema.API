﻿using WishCinema.Application.Models;
using WishCinema.Application.Result;

namespace WishCinema.Application.Services.Interfaces
{
    public interface ICinemas
    {
        public Task<Result<IEnumerable<SessionModel>>> GetSessionsByCinema(string cinemaTitle);
        public Task<Result<IEnumerable<CinemaModel>>> GetCinemasList();

    }
}