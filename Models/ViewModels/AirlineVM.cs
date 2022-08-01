using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public  class AirlineVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Discription { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
    }
}
