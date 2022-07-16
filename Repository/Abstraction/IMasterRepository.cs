using Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstraction
{
    public interface IMasterRepository
    {
        Task<List<MealType>> GetMealType();
        Task<List<Place>> GetPlaces();
        Task<List<Airline>> GetAirlines();
    }
}
