using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public class User : BaseEntity
{
    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public byte[] PasswordSalt { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual UserProfile UserProfile { get; set; } = new UserProfile();
}
