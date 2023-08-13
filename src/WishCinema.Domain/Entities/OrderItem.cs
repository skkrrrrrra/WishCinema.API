using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public class OrderItem : BaseEntity
{
    public OrderItem(DateTime createdAt, DateTime updatedAt, DateTime? deletedAt)
        : base(createdAt, updatedAt, deletedAt)
    {
    }
    public OrderItem() { }
    public long ProductId { get; set; }

    public long OrderId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
