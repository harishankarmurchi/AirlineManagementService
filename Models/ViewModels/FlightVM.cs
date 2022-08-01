using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class FlightVM
    {
        public int AirlineId { get; set; }
        public AirlineVM? Airline { get; set; }
        public string FlightNumber { get; set; }
        public int FlightId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string InstrumentUsed { get; set; }
        public int BusinessClassSeats { get; set; }
        public int NonBusinessClassSeats { get; set; }
        public int NoOfRows { get; set; }
        public double TicketCost { get; set; }
        public List<string> ShedhuleDays { get; set; }
        public int MealTypeId { get; set; }
        public int FromPlaceId { get; set; }
        public int ToPlaceId { get; set; }
        public string? ToPlaceName { get; set; }
        public string? FromPlaceName { get; set; }
        public string? MealTypeName { get; set; }

        public List<SeatVM>? Seats { get; set; }
    }
}
