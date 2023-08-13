using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public class Hall : BaseEntity
{
    public Hall(DateTime createdAt, DateTime updatedAt, DateTime? deletedAt) 
        : base(createdAt, updatedAt, deletedAt)
    {
    }

    public string Title { get; set; } = null!;

    public long CountOfPlaces { get; set; }

    public long CinemaId { get; set; }

    public virtual Cinema Cinema { get; set; } = null!;

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
