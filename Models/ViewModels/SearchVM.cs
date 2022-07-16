
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class SearchVM
    {
        public int ToPlaceId { get; set; }
        public int FromPlaceId { get; set; }
        public DateTime JourneyDate { get; set; }
        public int AirlineId { get; set; }
    }
}
