using WishCinema.Application.Responses;
using WishCinema.Application.Result;

namespace WishCinema.Application.Services.Interfaces
{
    public interface IProducts
    {
        public Task<Result<IEnumerable<ProductModel>>> GetProducts();
        public Task<Result<ProductModel>> GetProductInfo(long productId);
        public Task<Result<string>> BuyProduct(long productId);
    }
}