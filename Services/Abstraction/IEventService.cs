using Models.EventModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction
{
    public interface IEventService
    {
        bool UpdateFlightSeats(AirlineEM airlineEM);
    }
}
