using Models.DBModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstraction
{
    public interface IAirlineRepository
    {
        Flight AddFlight(Flight flight);
        Airline AddAirline(Airline airline);
        Flight UpdateAirline(Flight flight);
        List<Flight> SearchFlight(SearchVM search);
    }
}
