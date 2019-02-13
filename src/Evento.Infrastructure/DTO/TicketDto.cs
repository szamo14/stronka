using System;

namespace Evento.Infrastructure.DTO
{
    public class TicketDto
    {
        public Guid ID { get; set; }
        public int Seating { get; set; }
        public decimal Price { get; set; }
        public Guid? UserId { get; set; } // Guidnullowany typ nullowany
        public string Username { get; set; }
        public DateTime? PurchassAt { get;set; }
        public bool Purchased { get; set; }      
    }
}