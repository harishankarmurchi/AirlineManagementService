using Models.DBModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction
{
    public interface IMasterService
    {
        Task<MasterVM> GetMasterData();
        Task<List<Airline>> GetAirline();
    }
}
