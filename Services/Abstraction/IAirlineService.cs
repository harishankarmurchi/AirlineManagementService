using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction
{
    public interface IAirlineService
    {
        List<FlightVM> AddFlight(FlightVM airlineVm);
        bool UpdateFlight(FlightVM airlineVM);
        List<FlightVM> Search(SearchVM search);
        List<AirlineVM> AddAirline(AirlineVM airlineVm);
        Task<AirlineVM> BlockAirline(AirlineVM airline);
        Task<FlightVM> ResheduleFlight(ResheduleVM reshedule);



    }
}
