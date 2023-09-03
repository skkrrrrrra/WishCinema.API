using Microsoft.EntityFrameworkCore;
using WishCinema.Application.Responses;
using WishCinema.Application.Result;
using WishCinema.Application.Results;
using WishCinema.Application.Services.Interfaces;
using WishCinema.Persistence;

namespace WishCinema.Application.Services
{
    public class TicketsService : ITicketsService
    {
        private readonly MainDbContext _dbContext;
        private readonly IAuditUserProvider _auditUserProvider;
        public TicketsService(MainDbContext dbContext,
            IAuditUserProvider auditUserProvider)
        {
            _dbContext = dbContext;
            _auditUserProvider = auditUserProvider;
        }

        public Task<Result<TicketModel>> BookTicket(int sessionId, int placeId)
        {
            throw new NotImplementedException();
        }

        public Task<Result<TicketModel>> BuyTicket(int ticketId)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<IEnumerable<TicketModel>>> GetAllTickets()
        {
            var userId = _auditUserProvider.GetUserId();
            var tickets = await _dbContext.Tickets
                .Include(ticket => ticket.Place)
                .ThenInclude(place => place.Prices)
                .Where(ticket => ticket.UserId == userId && ticket.DeletedAt == null)
                .Select(ticket => new TicketModel(ticket))
                .ToListAsync();

            return new SuccessResult<IEnumerable<TicketModel>>(tickets);
        }
    }
}
