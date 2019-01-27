using System;

namespace Evento.Core.Domain
{
    public class Ticket : Entity
    {
        public Guid EventID { get; protected set;}
        public int Seating { get; protected set;}
        public decimal Price { get; protected set;}
        public Guid? UserId { get; protected set;} // Guidnullowany typ nullowany
        public string Username { get; protected set;}
        public DateTime? PurchassAt { get; protected set;}
        public bool Purchased => UserId.HasValue;

        protected Ticket()
        {
        }
        public  Ticket( Event @event, int seating, decimal price)
        {
            EventID = @event.ID;
            Seating = seating;
            Price = price;
            
        }

    }
}