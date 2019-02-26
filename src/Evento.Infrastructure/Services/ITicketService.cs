using System;
using System.Threading.Tasks;
using Evento.Infrastructure.DTO;

namespace Evento.Infrastructure.Services
{
    public interface ITicketService
    {
         Task<TicketDto> GetAsync(Guid userId, Guid eventId, Guid ticketId);
         Task PurchesAsync(Guid userId, Guid eventId, int amount);
         Task CancelAsync(Guid userId, Guid eventId, int amount);
         
    }
}