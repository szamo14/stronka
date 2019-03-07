using System.Linq;
using AutoMapper;
using Evento.Core.Domain;
using Evento.Infrastructure.DTO;

namespace Evento.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize ()
            => new MapperConfiguration( cfg => 
            {  
                cfg.CreateMap<Event,EventDto>()
                .ForMember(x=>x.AvailableTicketsCount, m=>m.MapFrom(p=>p.AvaiableTickets.Count()))
                .ForMember(x=>x.PurchasedTicetsCounts, m=>m.MapFrom(p=>p.PurchesedTickets.Count()))
                .ForMember(x=>x.TicketsCount, m=>m.MapFrom(p=>p.Tickets.Count()));              
                cfg.CreateMap<EventDto,EventDetailsDto>();
                //.ForMember(x=>x.AvailableTicketsCount, m=>m.MapFrom(p=>p.AvaiableTickets.Count()))
                //.ForMember(x=>x.PurchasedTicetsCounts, m=>m.MapFrom(p=>p.PurchesedTickets.Count()))
                //.ForMember(x=>x.TicketsCount, m=>m.MapFrom(p=>p.Tickets.Count()));
                cfg.CreateMap<Ticket,TicketDto>();
                cfg.CreateMap<User,AccountDto>();
            } )
            .CreateMapper();
    }
}