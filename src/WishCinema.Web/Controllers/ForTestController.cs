using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WishCinema.Application.Requests.Test;
using WishCinema.Application.Result;
using WishCinema.Application.Results;
using WishCinema.Application.Services;

namespace WishCinema.Web.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/test")]
    public class ForTestController : ControllerBase
    {
        private readonly ForTestService _testService;
        public ForTestController(ForTestService testService)
        {
            _testService = testService;
        }

        [Route("add-cinema")]
        [HttpPost]
        public async Task<Result<string>> AddCinema(AddCinemaRequest request)
        {
            if (request == null)
            {
                return new InvalidResult<string>("MODEL_NOT_VALID");
            }

            var result = await _testService.AddCinema(request);

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

            var result = await _testService.AddMovie(request);

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

            var result = await _testService.AddSession(request);

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

            var result = await _testService.AddHall(request);

            if (result.ResultType == Domain.Enums.ResultType.Invalid)
            {
                return new InvalidResult<string>(result.Error);
            }

            return new SuccessResult<string>(result.Data);
        }
    }
}
