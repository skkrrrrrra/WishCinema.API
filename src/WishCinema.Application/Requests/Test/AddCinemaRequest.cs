using WishCinema.Application.Requests.Base;

namespace WishCinema.Application.Requests.Test
{
    public class AddCinemaRequest : BaseRequest
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public decimal Lattitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
