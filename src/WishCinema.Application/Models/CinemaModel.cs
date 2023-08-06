using WishCinema.Domain.Entities;

namespace WishCinema.Application.Models
{
    public class CinemaModel
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public decimal Lattitude { get; set; }
        public decimal Longitude { get; set; }

        public CinemaModel(Cinema cinema)
        {
            Title = cinema.Title;
            Address = cinema.Address;
            Lattitude = cinema.Lattitude;
            Longitude = cinema.Longitude;
        }
    }
}
