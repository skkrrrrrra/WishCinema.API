using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WishCinema.Application.Requests.Test;
using WishCinema.Application.Result;
using WishCinema.Application.Results;
using WishCinema.Application.Services;
using WishCinema.Application.Services.Interfaces;

namespace WishCinema.Web.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [Route("add-cinema")]
        [HttpPost]
        public async Task<Result<string>> AddCinema(AddCinemaRequest request)
        {
            if (request == null)
            {
                return new InvalidResult<string>("MODEL_NOT_VALID");
            }

            var result = await _adminService.AddCinema(request);

            if (result.ResultType == Domain.Enums.ResultType.Invalid)
            {
                return new InvalidResult<string>(result.Error);
            }

            return new SuccessResult<string>(result.Data);
        }

        [Route("add-movie")]
        [HttpPost]
        public async Task<Result<string>> AddMovie(AddMovieRequest request)
        {
            if (request == null)
            {
                return new InvalidResult<string>("MODEL_NOT_VALID");
            }

            var result = await _adminService.AddMovie(request);

            if (result.ResultType == Domain.Enums.ResultType.Invalid)
            {
                return new InvalidResult<string>(result.Error);
            }

            return new SuccessResult<string>(result.Data);
        }

        [Route("add-session")]
        [HttpPost]
        public async Task<Result<string>> AddSession(AddSessionRequest request)
        {
            if (request == null)
            {
                return new InvalidResult<string>("MODEL_NOT_VALID");
            }

            var result = await _adminService.AddSession(request);

            if (result.ResultType == Domain.Enums.ResultType.Invalid)
            {
                return new InvalidResult<string>(result.Error);
            }

            return new SuccessResult<string>(result.Data);
        }

        [Route("add-hall")]
        [HttpPost]
        public async Task<Result<string>> AddHallToCinema(AddHallRequest request)
        {
            if (request == null)
            {
                return new InvalidResult<string>("MODEL_NOT_VALID");
            }

            var result = await _adminService.AddHall(request);

            if (result.ResultType == Domain.Enums.ResultType.Invalid)
            {
                return new InvalidResult<string>(result.Error);
            }

            return new SuccessResult<string>(result.Data);
        }

        [Route("add-product")]
        [HttpPost]
        public async Task<Result<string>> AddProduct(AddProductRequest request)
        {
            if (request == null)
            {
                return new InvalidResult<string>("MODEL_NOT_VALID");
            }

            var result = await _adminService.AddProduct(request);

            if (result.ResultType == Domain.Enums.ResultType.Invalid)
            {
                return new InvalidResult<string>(result.Error);
            }

            return new SuccessResult<string>(result.Data);
        }

        [Route("add-genre")]
        [HttpPost]
        public async Task<Result<string>> AddGenre(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return new InvalidResult<string>("TITLE_NOT_VALID");
            }

            var result = await _adminService.AddGenre(title);

            if (result.ResultType == Domain.Enums.ResultType.Invalid)
            {
                return new InvalidResult<string>(result.Error);
            }

            return new SuccessResult<string>(result.Data);
        }
        [Route("add-genre-to-movie")]
        [HttpPost]
        public async Task<Result<string>> AddGenreToMovie(AddGenreToMovieRequest request)
        {
            if (request == null)
            {
                return new InvalidResult<string>("TITLE_NOT_VALID");
            }

            var result = await _adminService.AddGenreToMovie(request);

            if (result.ResultType == Domain.Enums.ResultType.Invalid)
            {
                return new InvalidResult<string>(result.Error);
            }

            return new SuccessResult<string>(result.Data);
        }
    }
}
