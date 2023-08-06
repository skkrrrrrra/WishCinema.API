using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public partial class UserProfile : BaseEntity
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public long UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
