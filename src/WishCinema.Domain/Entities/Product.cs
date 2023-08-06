using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public class Product : BaseEntity
{
    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
