using WishCinema.Application.Requests.Base;
using WishCinema.Domain.Entities;

namespace WishCinema.Application.Requests.Test
{
    public class AddHallRequest : BaseRequest
    {
        public string Title { get; set; } = null!;

        public long CountOfPlaces { get; set; }

        public long CinemaId { get; set; }
    }
}
