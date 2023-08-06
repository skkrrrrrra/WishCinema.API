using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public class Hall : BaseEntity
{
    public string Title { get; set; } = null!;

    public long CountOfPlaces { get; set; }

    public virtual ICollection<Place> Places { get; set; } = new List<Place>();

    public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
}
