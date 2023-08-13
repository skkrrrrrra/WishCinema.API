using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public class GenresMovie : BaseEntity
{
    public GenresMovie(long genreId, long movieId, DateTime createdAt, DateTime updatedAt, DateTime? deletedAt)
        : base(createdAt, updatedAt, deletedAt)
    {
        GenreId = genreId;
        MovieId = movieId;
    }

    public long GenreId { get; set; }

    public long MovieId { get; set; }

    public virtual Genre Genre { get; set; } = null!;

    public virtual Movie Movie { get; set; } = null!;
}
