using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class MasterVM
    {
        public List<MealVm> MealTypes { get; set; }
        public List<PlaceVm> Places { get; set; }
    }
    public class MealVm
    {
        public int MealId { get; set; }
        public string MealType { get; set; }
    }
    public class PlaceVm
    {
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
    }
}
