using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Evento.Core.Domain;
using Evento.Core.Repositories;

namespace Evento.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private static readonly ISet<Event> _events = new HashSet<Event>
        {
            // create new events to check api (event 1 and event 2)
            new Event(Guid.NewGuid(),"event 1","event 1 description", DateTime.UtcNow.AddHours(2),DateTime.UtcNow.AddHours(4)),
            new Event(Guid.NewGuid(),"event 2","event 2 description", DateTime.UtcNow.AddHours(4),DateTime.UtcNow.AddHours(7))
        };

        public static ISet<Event> Events => _events;

        public async Task<Event> GetAsync(Guid id)
            => await Task.FromResult(Events.SingleOrDefault(x=>x.Id==id));
        public async Task<Event> GetAsync(string name)
            => await Task.FromResult(Events.SingleOrDefault(x=>x.Name.ToLowerInvariant()==name.ToLowerInvariant()));
         public async Task<IEnumerable<Event>> BrowseAsync(string name = "")
        {
            var events = Events.AsEnumerable();
            if(!string.IsNullOrWhiteSpace(name))
            {
                events = events.Where(x=>x.Name.ToLowerInvariant().Contains(name.ToLowerInvariant()));
            }
            return await Task.FromResult(events);
        }
        public async Task AddAsync(Event @event)
        { 
            Events.Add(@event);
            await Task.CompletedTask;
        }
        public async Task UpdateAsync(Event @event)
        {
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(Event @event)
        {
            Events.Remove(@event);
            await Task.CompletedTask;
        }


      
    }
}