using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstraction
{
    public interface IEventRepository
    {
        bool UpdateFlightSeats(List<string> seatNos, int flightId, bool status);
    }
}
