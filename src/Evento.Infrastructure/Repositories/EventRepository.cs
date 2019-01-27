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
        private static readonly ISet<Event> _events = new HashSet<Event>();
        
        public async Task<Event> GetAsync(Guid id)
        => await Task.FromResult(_events.SingleOrDefault(x=>x.ID==id));
        public async Task<Event> GetAsync(string name)
         => await Task.FromResult(_events.SingleOrDefault(x=>x.Name.ToLowerInvariant()==name.ToLowerInvariant()));
         public async Task<IEnumerable<Event>> BrowseAsync(string name = "")
        {
            throw new NotImplementedException();
        }
        public async Task AddAsync(Event @event)
        { 
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Event @event)
        {
            throw new NotImplementedException();
        }


        public async Task UpdateAsync(Event @event)
        {
            throw new NotImplementedException();
        }
    }
}