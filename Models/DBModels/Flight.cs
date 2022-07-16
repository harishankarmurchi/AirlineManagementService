using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DBModels
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string InstrumentUsed { get; set; }
        public int BusinessClassSeats { get; set; }
        public int NonBusinessClasssSeats { get; set; }
        public int NoOfRows { get; set; }
        public double TicketCost { get; set; }
        public string ShedhuleDays { get; set; }

        //ForenKey from Airline
        public int AirlineId { get; set; }
        public Airline Airline { get; set; }


        //Foren key for Meal
        public int MealTypeId { get; set; }
        public MealType MealType { get; set; }

        //Seats
        public List<FlightSeats>? Seats { get; set; }


        //ForenKes for place
        public int FromPlaceId { get; set; }
        public Place FromPlace { get; set; }

        public int ToPlaceId { get; set; }
        public Place ToPlace { get; set; }





    }
}
