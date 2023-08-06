using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public class Genre : BaseEntity
{
    public string Title { get; set; } = null!;

    public virtual ICollection<GenresMovie> GenresMovies { get; set; } = new List<GenresMovie>();
}
