using System;
using System.Collections.Generic;

namespace Evento.Infrastructure.DTO
{
    public class EventDto
    {
        public Guid Id { get; set;}
        public string Name { get;  set; }
        public string Description { get; set; }
        public DateTime StartDate { get;  set; }
        public DateTime EndDate { get;  set; }
        public object TicketsCount { get; set; }
        public int PurchasedTicetsCounts { get; set; }
        public int AvailableTicketsCount { get; set; }
    }
}