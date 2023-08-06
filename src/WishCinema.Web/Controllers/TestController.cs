using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WishCinema.Web.Controllers
{
    public class TestController : ControllerBase
    {

        [HttpPost]
        [Authorize]
        [Route("test")]
        public async Task<string> Test()
        {
            return "success";
        }
    }
}
