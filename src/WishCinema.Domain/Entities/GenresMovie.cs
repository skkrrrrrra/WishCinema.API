using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public class GenresMovie : BaseEntity
{
    public long GenreId { get; set; }

    public long MovieId { get; set; }

    public virtual Genre Genre { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
