using System;
using System.Threading.Tasks;
using Evento.Infrastructure.DTO;

namespace Evento.Infrastructure.Services
{
    public class TicektService : ITicketService
    {
        public Task CancelAsync(Guid userId, Guid eventId, int amount)
        {
            throw new NotImplementedException();
        }

        public Task<TicketDto> GetAsync(Guid userId, Guid eventId, Guid ticketId)
        {
            throw new NotImplementedException();
        }

        public Task PurchesAsync(Guid userId, Guid eventId, int amount)
        {
            throw new NotImplementedException();
        }
    }
}