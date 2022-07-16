using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DBModels
{
    public class Place
    {
        public int Id { get; set; }
        public string PlaceName { get; set; }
        public bool IsActive { get; set; }

        public List<Flight> ToFlights { get; set; }
        public List<Flight> FromFlights { get; set; }
    }
}
