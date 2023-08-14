﻿using Microsoft.EntityFrameworkCore;
using WishCinema.Application.Responses;
using WishCinema.Application.Result;
using WishCinema.Application.Results;
using WishCinema.Application.Services.Interfaces;
using WishCinema.Persistence;

namespace WishCinema.Application.Services
{
    public class Products : IProducts
    {
        private readonly MainDbContext _dbContext;
        public Products(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Result<string>> BuyProduct(long productId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<ProductModel>> GetProductInfo(long productId)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(product => product.Id == productId);

            if(product != null)
            {
                var response = new ProductModel(product);
                return new SuccessResult<ProductModel>(response);
            }
            return new InvalidResult<ProductModel>("PRODUCT_DOES_NOT_EXIST");
        }

        public async Task<Result<IEnumerable<ProductModel>>> GetProducts()
        {
            var products = await _dbContext.Products
                .Where(product => product.DeletedAt == null)
                .Select(product => new ProductModel(product))
                .ToListAsync();

            // ToListAsync никогда не вернет null
            return products.Any()
                ? new SuccessResult<IEnumerable<ProductModel>>(products)
                : new InvalidResult<IEnumerable<ProductModel>>("NO_PRODUCTS");
        }
    }
}
