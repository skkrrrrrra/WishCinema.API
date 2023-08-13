using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public class Product : BaseEntity
{
    public Product(DateTime createdAt, DateTime updatedAt, DateTime? deletedAt) 
        : base(createdAt, updatedAt, deletedAt)
    {
    }

    public string Title { get; set; } = null!;

    public string ImagePath { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; } = default!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
