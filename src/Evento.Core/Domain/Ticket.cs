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
        public  Ticket(Event @event, int seating, decimal price)
        {
            EventID = @event.Id;
            Seating = seating;
            Price = price;
            
        }

        public void Purchase (User user)
        {
            if (Purchased)
            {
                throw new Exception($"Ticket was already purchased by '{Username}' at  {PurchassAt}");
            }

            UserId = user.Id;
            Username = user.Name;
            PurchassAt = DateTime.UtcNow;
        }
        public void Cancel (User user)
        {
            if (!Purchased)
            {
                throw new Exception($"Ticket was not purchased and can not be cancel");
            }

            UserId = null;
            Username = null;
            PurchassAt = null;
        }
    }
}