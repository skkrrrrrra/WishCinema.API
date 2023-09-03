using WishCinema.Domain.Entities.Base;

namespace WishCinema.Domain.Entities;

public class Ticket : BaseEntity
{
    public long PlaceId { get; set; }

    public long SessionId { get; set; }

    public long State { get; set; }

    public long? UserId { get; set; }

    public virtual Place Place { get; set; } = null!;

    public virtual Session Session { get; set; } = null!;

    public virtual User User { get; set; } = null!;
    public Ticket(long placeId, long sessionId, long state, int? userId, DateTime createdAt, DateTime updatedAt, DateTime? deletedAt)
        : base(createdAt, updatedAt, deletedAt)
    {
        PlaceId = placeId; 
        SessionId = sessionId; 
        State = state;
        UserId = userId;
    }
    public Ticket() { }
}
