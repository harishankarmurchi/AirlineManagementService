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
        bool AddAirline(AirlineVM airlineVm);
        bool UpdateFlight(AirlineVM airlineVM);
        List<AirlineVM> Search(SearchVM search);



    }
}
