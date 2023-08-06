using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public class Role : BaseEntity
{
    public string Title { get; set; } = null!;

    public long UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
