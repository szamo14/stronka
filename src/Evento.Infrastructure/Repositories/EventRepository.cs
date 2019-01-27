using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Evento.Core.Domain;
using Evento.Core.Repositories;

namespace Evento.Infrastructure.Repositories
{
    public class EventRepository : IEventRepository
    {
        private static readonly ISet<Event> _events = new HashSet<Event>();
        public async Task AddAsync(Event @event)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Event>> BrowseAsync(string name = "")
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Event @event)
        {
            throw new NotImplementedException();
        }

        public async Task<Event> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Event> GetAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Event @event)
        {
            throw new NotImplementedException();
        }
    }
}