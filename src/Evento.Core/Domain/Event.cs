using System;
using System.Collections.Generic;

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

        protected Event()
        {

        }

        public Event ( Guid id, string name, string description, DateTime startData, DateTime endDate)
        {
            ID = id;
            Name = name;
            Description = description;
            StartDate = startData;
            EndDate = endDate;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;

        }

        public void AddTickets( int amount, decimal price) 
        {
             for(var i=0; i<amount; i++)
             {
                  _tickets.Add(new Ticket());
             }
        }


    }
}