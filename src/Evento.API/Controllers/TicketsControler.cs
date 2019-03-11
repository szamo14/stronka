using System;
using System.Threading.Tasks;
using Evento.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Evento.API.Controllers
{
    [Authorize]    
    [Route ("events/{eventId}/tickets")]
    public class TicketsControler : ApiControlerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsControler (ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [HttpGet("{ticketId}")]
        public async Task<IActionResult> Get(Guid eventId, Guid ticketId)
        {
            var ticket = await _ticketService.GetAsync(UserId,eventId, ticketId);
            return Json(ticket);
        }
        [HttpPost("purchase/{amount}")]
        public async Task<IActionResult> Post(Guid eventId, int amount)
        {
            await _ticketService.PurchesAsync(UserId, eventId, amount);
            return NoContent();
        }
        [HttpDelete("cancel/{amount}")]
        public async Task<IActionResult> Delete(Guid eventId, int amount)
        {
            await _ticketService.CancelAsync(UserId, eventId, amount);
            return NoContent();
        }
    }
}