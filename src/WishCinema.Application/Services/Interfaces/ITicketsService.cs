using WishCinema.Application.Responses;
using WishCinema.Application.Result;

namespace WishCinema.Application.Services.Interfaces
{
    public interface ITicketsService
    {
        public Task<Result<IEnumerable<TicketModel>>> GetAllTickets();
        public Task<Result<TicketModel>> BookTicket(int sessionId, int placeId);
        public Task<Result<TicketModel>> BuyTicket(int ticketId);
    }
}