using Models.EventModel;
using Repository.Abstraction;
using Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepo;
        public EventService(IEventRepository eventRepo)
        {
            _eventRepo = eventRepo;
        }
    
        public bool UpdateFlightSeats(AirlineEM airlineEM)
        {
            try
            {
                return _eventRepo.UpdateFlightSeats(airlineEM.SeatNos, airlineEM.FlightId, airlineEM.Status);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
