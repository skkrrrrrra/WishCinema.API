using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public class Price : BaseEntity
{
    public Price(DateTime createdAt, DateTime updatedAt, DateTime? deletedAt) 
        : base(createdAt, updatedAt, deletedAt)
    {
    }

    public decimal Value { get; set; }

    public long PlaceId { get; set; }

    public virtual Place Place { get; set; } = null!;
}
