using Microsoft.EntityFrameworkCore;
using Models.DBModels;
using Models.ViewModels;
using Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repos
{
    public class AirlineRepository: IAirlineRepository
    {
        private readonly AirlineDbContext _dbContext;
        public AirlineRepository(AirlineDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Flight AddFlight(Flight flight)
        {
            try
            {
                var result =  _dbContext.Flights.FirstOrDefault(x => x.FlightNumber == flight.FlightNumber && x.StartDate==flight.StartDate);
                if (result == null)
                {
                    _dbContext.Flights.Add(flight);
                     _dbContext.SaveChanges();
                    return flight;
                }
                throw new Exception("Flight with same No and Date already Exist");
            }catch(Exception ex)
            {
                throw;
            }
        }

        public Airline AddAirline(Airline airline)
        {
            try
            {
                var result =  _dbContext.Airlines.FirstOrDefault(x => x.Name == airline.Name);
                if(result == null)
                {
                    _dbContext.Airlines.Add(airline);
                    _dbContext.SaveChanges();
                    return airline;
                }
                return result;

            }catch(Exception ex)
            {
                throw;
            }
        }

        public Flight UpdateAirline(Flight flight)
        {
            try
            {
                var result = _dbContext.Flights.Include("Airline")
                    .Include("MealType").Include("FromPlace").Include("ToPlace")
                    .Include("Seats")
                    .FirstOrDefault(x => x.FlightNumber == flight.FlightNumber);
                if (result != null)
                {
                    result.StartDate = flight.StartDate;
                    result.EndDate = flight.EndDate;
                    result.Airline.IsActive = flight.Airline.IsActive;
                    result.ShedhuleDays = flight.ShedhuleDays;
                    result.TicketCost = flight.TicketCost;
                    _dbContext.Flights.Update(result);
                    _dbContext.SaveChanges();
                }
                return result;

            }catch(Exception ex)
            {
                throw;
            }
        }

        public List<Flight> SearchFlight(SearchVM search)
        {
            try
            {
                var result = _dbContext.Flights.Include("Airline")
                    .Include("MealType").Include("FromPlace").Include("ToPlace")
                    .Include("Seats")
                    .Where(
                      x => x.ToPlaceId == search.ToPlaceId &&
                      x.FromPlaceId==search.FromPlaceId &&
                      x.NonBusinessClasssSeats+x.BusinessClassSeats>0 &&
                      x.StartDate.Date== search.JourneyDate.Date &&
                      x.Airline.IsActive== true
                    ).ToList();
                return result;


            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
