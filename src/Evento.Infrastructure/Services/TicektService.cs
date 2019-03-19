using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Evento.Core.Repositories;
using Evento.Infrastructure.DTO;
using Evento.Infrastructure.Extensions;

namespace Evento.Infrastructure.Services
{
    public class TicektService : ITicketService
    {
        private IUserRepository _userRepository;
        private IEventRepository _eventRepository;
        private IMapper _mapper;

        public TicektService(IUserRepository userRepository, IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository; 
            _mapper = mapper; 

        }        
        public async Task CancelAsync(Guid userId, Guid eventId, int amount)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var @event = await _eventRepository.GetOrFailAsync(eventId);
            @event.CancelPurchesTickets(user,amount);
            await _eventRepository.UpdateAsync(@event);
        }

        public async Task<TicketDto> GetAsync(Guid userId, Guid eventId, Guid ticketId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var ticket = await _eventRepository.GetTicketOrFailAsync(eventId, ticketId);

            return _mapper.Map<TicketDto>(ticket);

        }

        public async Task<IEnumerable<TicketDetailsDto>> GetForUserAsync(Guid userId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var events = await _eventRepository.BrowseAsync();
            
            var allTickets = new List<TicketDetailsDto>();
            foreach (var @event in events)
            {
                var tickets = _mapper.Map<IEnumerable<TicketDetailsDto>>(@event.GetTicketsPurchasedByUser(user)).ToList();
                tickets.ForEach(x => 
                {
                     x.EventId = @event.Id;
                     x.EventName = @event.Name;
                });
                allTickets.AddRange(tickets);
            }
            return allTickets;
            
            
        }

        public async Task PurchesAsync(Guid userId, Guid eventId, int amount)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var @event = await _eventRepository.GetOrFailAsync(eventId);
            @event.PurchesTickets(user,amount);
            await _eventRepository.UpdateAsync(@event);
        }

       
    }
}