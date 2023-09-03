using WishCinema.Domain.Entities;

namespace WishCinema.Application.Responses
{
    public class TicketModel
    {
        public long Id { get; set; }

        public decimal Price { get; set; }

        public PlaceModel Place { get; set; }

        public SessionModel Session { get; set; }

        public TicketModel(Ticket ticket)
        {
            Id = ticket.Id;
            Price = ticket.Place.Prices.FirstOrDefault().Value;
            ticket.Session.Tickets = null;
        }
    }
}
