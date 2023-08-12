using WishCinema.Application.Services;

namespace WishCinema.Application.Requests.Base
{
    public class BaseRequest
    {
        public DateTime CreatedAt { get; private set; } = DateHelper.GetCurrentDateTime();
        public DateTime UpdatedAt { get; private set; } = DateHelper.GetCurrentDateTime();
        public DateTime? DeletedAt { get; private set; } = null!;
    }
}
