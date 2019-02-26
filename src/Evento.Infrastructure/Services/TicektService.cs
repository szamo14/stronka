using System;
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

        public async Task PurchesAsync(Guid userId, Guid eventId, int amount)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            var @event = await _eventRepository.GetOrFailAsync(eventId);
            @event.PurchesTickets(user,amount);
            await _eventRepository.UpdateAsync(@event);
        }
    }
}