namespace WishCinema.Domain.Entities.Base;

public class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public BaseEntity(DateTime createdAt, DateTime updatedAt, DateTime? deletedAt)
    {
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DeletedAt = deletedAt;
    }
    public BaseEntity()
    {

    }
}
