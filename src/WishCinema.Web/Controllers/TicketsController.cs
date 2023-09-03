using Microsoft.AspNetCore.Mvc;
using WishCinema.Application.Responses;
using WishCinema.Application.Result;
using WishCinema.Application.Services.Interfaces;
using WishCinema.Domain.Entities;

namespace WishCinema.Web.Controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketsService _ticketsService;

        public TicketsController(ITicketsService ticketsService) 
        {
            _ticketsService = ticketsService;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<Result<IEnumerable<TicketModel>>> GetAllTickets()
        {
            var result = await _ticketsService.GetAllTickets();
            return result;
        }

        public Task<Result<TicketModel>> BookTicket(int sessionId, int placeId)
        {

        }

        public Task<Result<TicketModel>> BuyTicket(int ticketId)
        {

        }
    }
}
