using WishCinema.Domain.Entities;

namespace WishCinema.Application.Models
{
    public class SessionModel
    {
        public long Id { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public MovieModel Movie { get; set; } = null!;

        public long HallId { get; set; }

        public IEnumerable<Ticket> Tickets { get; set; } = new List<Ticket>();


        public SessionModel(Session session)
        {
            Id = session.Id;
            StartDate = session.StartDate; 
            EndDate = session.EndDate;
            Movie = new MovieModel(session.Movie);
            Tickets = session.Tickets;
            HallId = session.HallId;
        }
    }
}
