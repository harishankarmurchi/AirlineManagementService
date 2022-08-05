using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EventModel
{
    public class AirlineEM
    {
        public int FlightId { get; set; }
        public List<string> SeatNos { get; set; }=new List<string>();
        public bool Status { get; set; }

    }
}
