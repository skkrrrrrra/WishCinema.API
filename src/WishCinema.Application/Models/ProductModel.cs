using WishCinema.Domain.Entities;

namespace WishCinema.Application.Models
{
    public class ProductModel
    {
        public string Title { get; set; } = null!;

        public string ImagePath { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; } = default!;

        public ProductModel(Product product)
        {
            Title = product.Title;
            ImagePath = product.ImagePath;
            Description = product.Description;
            Price = product.Price;
        }
    }
}
