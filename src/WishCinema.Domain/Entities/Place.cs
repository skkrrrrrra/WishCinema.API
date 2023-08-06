using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public class Place : BaseEntity
{
    public long HallId { get; set; }

    public virtual Hall Hall { get; set; } = null!;

    public virtual ICollection<Price> Prices { get; set; } = new List<Price>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
