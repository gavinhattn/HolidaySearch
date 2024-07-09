using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidaySearch
{
    public class Hotel
    {

        public int Id { get; set; }

        public IList<string> LocalAirports { get; set; }

        public int Price { get; set; }

        public int Nights { get; set; }

        public DateTime ArrivalDate { get; set; }

    }
}
