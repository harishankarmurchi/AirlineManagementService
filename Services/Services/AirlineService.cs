using AutoMapper;
using Models.DBModels;
using Models.ViewModels;
using Repository.Abstraction;
using Repository.Repos;
using Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public  class AirlineService: IAirlineService
    {
        private readonly IAirlineRepository _airRepo;
        private readonly IMapper _mapper;
        public AirlineService(IAirlineRepository airRepo, IMapper mapper)
        {
            _airRepo = airRepo;
            _mapper = mapper;

        }

        public bool AddAirline(AirlineVM airlineVm)
        {
            try
            {
                var airline = _mapper.Map<Airline>(airlineVm);
                airline =  _airRepo.AddAirline(airline);
                var flight = _mapper.Map<Flight>(airlineVm);
                flight.AirlineId = airline.Id;
                flight.Seats = formFlightSeats(flight.NoOfRows, flight.NonBusinessClasssSeats, "B");
                flight.Seats.AddRange(formFlightSeats(flight.NoOfRows, flight.NonBusinessClasssSeats, "NB"));
                var response =  _airRepo.AddFlight(flight);
                if (response != null) return true;
                return false;
               

            }
            catch(Exception ex)
            {
                throw;
            }
        }

        private List<FlightSeats> formFlightSeats(int noOfRows,int seats, string type)
        {
            int rows = noOfRows;
            int cols = (seats / noOfRows);
            const int asciino = 64;
            List<FlightSeats> seatsList = new List<FlightSeats>();
            for(int i = 1; i <=cols; i++)
            {
                for(int j = 1; j <=rows; j++)
                {
                    var seatNo = i.ToString() + ((char)(j + asciino)).ToString();
                    var flightseat =new FlightSeats
                    {
                        SeatName = seatNo,
                        IsBooked = false,
                        Type = type
                        
                    };
                    seatsList.Add(flightseat);
                }
            }
            return seatsList;
        }

        public bool UpdateFlight(AirlineVM airlineVM)
        {
            try
            {
                var airline = _mapper.Map<Airline>(airlineVM);
                var flight = _mapper.Map<Flight>(airlineVM);
                flight.Airline = airline;
                flight.AirlineId = airline.Id;
                var result =_airRepo.UpdateAirline(flight);
                if (result != null) return true;
                return false;


            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public List<AirlineVM> Search(SearchVM search)
        {
            try
            {
                var result = _airRepo.SearchFlight(search);
                return _mapper.Map<List<AirlineVM>>(result);

            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
