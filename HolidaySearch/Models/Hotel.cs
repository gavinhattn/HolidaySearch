using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HolidaySearch.Models
{
    public class Hotel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("local_airports")]
        public IList<string> LocalAirports { get; set; }

        [JsonPropertyName("price_per_night")]
        public int Price { get; set; }

        [JsonPropertyName("nights")]
        public int Nights { get; set; }

        [JsonPropertyName("arrival_date")]
        public DateTime ArrivalDate { get; set; }

    }
}
