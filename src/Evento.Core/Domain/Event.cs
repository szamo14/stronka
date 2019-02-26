using System;
using System.Collections.Generic;
using System.Linq;

namespace Evento.Core.Domain
{
    public class Event : Entity
    {
        private ISet<Ticket> _tickets = new HashSet<Ticket>();
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public IEnumerable<Ticket> Tickets => _tickets;
        public IEnumerable<Ticket> PurchesedTickets => _tickets.Where(x => x.Purchased);
        public IEnumerable<Ticket> AvaiableTickets => _tickets.Except(PurchesedTickets);
        protected Event()
        {

        }

        public Event ( Guid id, string name, string description, DateTime startData, DateTime endDate)
        {
            Id = id;
            SetName(name);
            SetDescription(description);
            Description = description;
            StartDate = startData;
            EndDate = endDate;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;

        }

        public void SetName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new Exception($"event with id : '{Id}' name can not be empty");
            }
            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }
        public void SetDescription(string description)
        {
             if(string.IsNullOrWhiteSpace(description))
            {
                throw new Exception($"event with id : '{Id}' description can not be empty");
            }
            Description = description;
            UpdatedAt = DateTime.UtcNow;

        }
        public void AddTickets( int amount, decimal price) 
        {
            var seating = _tickets.Count + 1;// pierwsze miejsce i nastepne 
             for(var i=0; i<amount; i++)
             {
                  _tickets.Add(new Ticket(this, seating, price));
                  seating++; // inkrementacje miejsc 
             }
        }

        public void PurchesTickets(User user, int amount)
        {
            if (AvaiableTickets.Count() < amount )
            {
                throw new Exception("not enough tickets");
            }
            var tickets = AvaiableTickets.Take(amount);
            foreach(var ticket in tickets)
            {
                ticket.Purchase(user);
            }

        }

          public void CancelPurchesTickets(User user, int amount)
        {
           var tickets = PurchesedTickets.Where(x =>x.UserId == user.Id);
            if(tickets.Count()<amount)
            {
                throw new Exception("not enough bought ticekts");
            }
            foreach(var ticket in tickets)
            {
                ticket.Cancel(user);
            }

            
        }

    }
}