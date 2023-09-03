using Microsoft.AspNetCore.Mvc;
using WishCinema.Application.Responses;
using WishCinema.Application.Result;
using WishCinema.Application.Services.Interfaces;

namespace WishCinema.Web.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly IAuditUserProvider _auditUserProvider;
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<Result<IEnumerable<ProductModel>>> ProductsList()
        {
            var result = await _productsService.GetProducts();
            return result;
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<Result<ProductModel>> ProductInfo(long productId)
        {
            var result = await _productsService.GetProductInfo(productId);
            return result;
        }
    }
}
