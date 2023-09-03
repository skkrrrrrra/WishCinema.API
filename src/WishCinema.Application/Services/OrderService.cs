using Microsoft.EntityFrameworkCore;
using WishCinema.Application.Result;
using WishCinema.Application.Results;
using WishCinema.Application.Services.Interfaces;
using WishCinema.Domain.Entities;
using WishCinema.Persistence;

namespace WishCinema.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly MainDbContext _dbContext;
        public OrderService(MainDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Result<bool>> AddToCartShop(int productId, int categoryType, long userId)
        {
            var order = await _dbContext.Orders
                .FirstOrDefaultAsync(item => item.State == 0);

            if (order == null)
            {
                order = new Order()
                {
                    State = 0,
                    TotalOrderitemsPrice = 0,
                    UserId = userId
                };
                await _dbContext.Orders.AddAsync(order);
                await _dbContext.SaveChangesAsync();
            }

            var orderItem = new OrderItem()
            {
                ProductId = productId,
                CategoryId = categoryType,
                OrderId = order.Id
            };
            await _dbContext.OrderItems.AddAsync(orderItem);
            await _dbContext.SaveChangesAsync();
            return new SuccessResult<bool>(true);
        }

    }
}
