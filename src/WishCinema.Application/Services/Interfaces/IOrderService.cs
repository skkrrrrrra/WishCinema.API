using WishCinema.Application.Result;

namespace WishCinema.Application.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<Result<bool>> AddToCartShop(int productId, int categoryType, long userId);
    }
}