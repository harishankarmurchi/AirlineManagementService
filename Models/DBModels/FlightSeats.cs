using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DBModels
{
    public class FlightSeats
    {
        public int Id { get; set; }
        public string SeatName { get; set; }
        public bool IsBooked { get; set; }
        public string Type { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; }
    }
}
