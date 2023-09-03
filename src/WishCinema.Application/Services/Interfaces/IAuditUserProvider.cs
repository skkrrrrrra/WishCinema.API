namespace WishCinema.Application.Services.Interfaces
{
    public interface IAuditUserProvider
    {
        long? GetUserId();
        string GetUserRole();
    }
}