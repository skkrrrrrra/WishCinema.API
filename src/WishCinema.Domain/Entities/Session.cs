using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public class Session : BaseEntity
{
    public Session(DateTime createdAt, DateTime updatedAt, DateTime? deletedAt) 
        : base(createdAt, updatedAt, deletedAt)
    {
    }
    public Session() { }

    public long CinemaId { get; set; }

    public long HallId { get; set; }

    public long MovieId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual Cinema Cinema { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;

    public virtual Hall Hall { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
