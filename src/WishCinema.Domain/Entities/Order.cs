using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public class Order : BaseEntity
{
    public Order(DateTime createdAt, DateTime updatedAt, DateTime? deletedAt) 
        : base(createdAt, updatedAt, deletedAt)
    {
    }
    public Order() { }
    public long OrderNumber { get; set; }

    public decimal TotalOrderitemsPrice { get; set; }

    public long UserId { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual User User { get; set; } = null!;
}
