using Microsoft.EntityFrameworkCore;
using Models.DBModels;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repos
{
    public class MasterRepository: IMasterRepository
    {
        private readonly AirlineDbContext _dbContext;
        public MasterRepository(AirlineDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MealType>> GetMealType()
        {
            try
            {
                return await _dbContext.MealTypes.ToListAsync();
            }catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Place>> GetPlaces()
        {
            try
            {
                return await _dbContext.Places.ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Airline>> GetAirlines()
        {
            try
            {
                return await _dbContext.Airlines.Where(x => x.IsActive == true).ToListAsync();

            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
