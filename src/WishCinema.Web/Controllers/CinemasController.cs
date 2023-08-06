using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WishCinema.Application.Models;
using WishCinema.Application.Result;
using WishCinema.Application.Services.Interfaces;

namespace WishCinema.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/cinemas")]
    public class CinemasController : ControllerBase
    {
        private readonly ICinemas _cinemasService;
        public CinemasController(ICinemas cinemasService)
        {
            _cinemasService = cinemasService;
        }
        [HttpGet]
        public async Task<Result<IEnumerable<CinemaModel>>> GetCinemasList()
        {
            var result = await _cinemasService.GetCinemasList();
            return result;
        }

        [HttpGet]
        [Route("{cinemaTitle}")]
        public async Task<Result<IEnumerable<SessionModel>>> GetSessionByCinemaId([FromRoute] string cinemaTitle)
        {
            var result = await _cinemasService.GetSessionsByCinema(cinemaTitle);
            return result;
        }
    }
}
