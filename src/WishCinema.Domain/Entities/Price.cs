using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public class Price : BaseEntity
{
    public decimal Price1 { get; set; }

    public long PlaceId { get; set; }

    public virtual Place Place { get; set; } = null!;
}
