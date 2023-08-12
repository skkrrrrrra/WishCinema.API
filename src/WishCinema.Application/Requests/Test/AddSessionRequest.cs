using WishCinema.Application.Requests.Base;

namespace WishCinema.Application.Requests.Test
{
    public class AddSessionRequest : BaseRequest
    {
        public long CinemaId { get; set; }

        public long HallId { get; set; }

        public long MovieId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
