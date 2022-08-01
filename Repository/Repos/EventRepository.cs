using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repos
{
    public class EventRepository:IEventRepository
    {
        private readonly AirlineDbContext _dbContext;
        public EventRepository(AirlineDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public  bool UpdateFlightSeats(List<string> seatNos, int flightId, bool status)
        {
            try
            {
                var result = _dbContext.Seats.Where(x => x.FlightId == flightId && seatNos.Contains(x.SeatName)).ToList();
                foreach (var item in result)
                {
                    item.IsBooked = status;
                    _dbContext.Seats.Update(item);
                }
                
                _dbContext.SaveChanges();
               // _dbContext.Dispose();
                return true;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
