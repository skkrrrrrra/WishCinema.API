using WishCinema.Domain.Entities.Base;


namespace WishCinema.Domain.Entities;

public class Cinema : BaseEntity
{
    public Cinema() { }
    public Cinema(DateTime createdAt, DateTime updatedAt, DateTime? deletedAt) 
        : base(createdAt, updatedAt, deletedAt)
    {
    }

    public string Title { get; set; } = null!;

    public string Address { get; set; } = null!;

    public decimal Lattitude { get; set; }

    public decimal Longitude { get; set; }

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();

    public virtual ICollection<Hall> Halls { get; set; } = new List<Hall>();
}
