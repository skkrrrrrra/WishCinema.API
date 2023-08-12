using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WishCinema.Application.Models;
using WishCinema.Application.Result;
using WishCinema.Application.Services.Interfaces;

namespace WishCinema.Web.Controllers
{
    [ApiController]
    [Route("api/cinemas")]
    [AllowAnonymous]
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
        [Route("{cinemaTitle}/sessions")]
        public async Task<Result<IEnumerable<SessionModel>>> GetSessionsByCinemaTitle([FromRoute] string cinemaTitle)
        {
            var result = await _cinemasService.GetSessionsByCinema(cinemaTitle);
            return result;
        }

        [HttpGet]
        [Route("{cinemaTitle}/sessions/{sessionId}")]
        public async Task<Result<SessionModel>> GetSessionByCinemaId([FromRoute] string cinemaTitle, [FromRoute] int sessionId)
        {
            var result = await _cinemasService.GetSessionInfo(cinemaTitle, sessionId);
            return result;
        }
    }
}
