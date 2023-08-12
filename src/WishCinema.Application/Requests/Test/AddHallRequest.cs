using WishCinema.Domain.Entities;

namespace WishCinema.Application.Requests.Test
{
    public class AddHallRequest
    {
        public string Title { get; set; } = null!;

        public long CountOfPlaces { get; set; }

        public long CinemaId { get; set; }

        public virtual Cinema Cinema { get; set; } = null!;
    }
}
