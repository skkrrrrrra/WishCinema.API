using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public class OrderItem : BaseEntity
{
    public OrderItem(long productId, long categoryId, long orderId, 
        DateTime createdAt, DateTime updatedAt, DateTime? deletedAt)
        : base(createdAt, updatedAt, deletedAt)
    {
        ProductId = productId;
        CategoryId = categoryId;
        OrderId = orderId;
    }
    public OrderItem() { }

    public long ProductId { get; set; }

    public long CategoryId { get; set; }

    public long OrderId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
