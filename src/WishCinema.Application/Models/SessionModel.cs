using WishCinema.Domain.Entities;

namespace WishCinema.Application.Models
{
    public class SessionModel
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Movie Movie { get; set; } = null!;

        public Hall Hall { get; set; } = null!;

        public IEnumerable<Ticket> Tickets { get; set; } = new List<Ticket>();


        public SessionModel(Session session)
        {
            StartDate = session.StartDate; 
            EndDate = session.EndDate;
            Movie = session.Movie;
            Tickets = session.Tickets;
            Hall = session.Hall;
        }
    }
}
