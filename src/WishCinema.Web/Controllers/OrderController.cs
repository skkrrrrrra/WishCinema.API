using Microsoft.AspNetCore.Mvc;
using WishCinema.Application.Result;
using WishCinema.Application.Services.Interfaces;

namespace WishCinema.Web.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService) 
        {
            _orderService = orderService;
        }

        public async Task<Result<bool>> AddToCartShop(long productId, long categoryType, long userId)
        {
            var result = await _orderService.AddToCartShop(productId, categoryType, userId);
            return result;
        }
    }
}
