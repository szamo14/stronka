using System.Collections;
using System.Collections.Generic;

namespace Evento.Infrastructure.DTO
{
    public class EventDetailsDto : EventDto
    {
        public IEnumerable<TicketDto> Ticekts{ get; set; }
    }
}