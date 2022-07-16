using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DBModels
{
    public class MealType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public List<Flight> Flights { get; set; }
    }
}
