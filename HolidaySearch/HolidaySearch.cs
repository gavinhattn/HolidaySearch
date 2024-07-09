using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HolidaySearch
{
    public class HolidaySearch(LowestCostCalculator lowCostCalculator)
    {
        private readonly LowestCostCalculator _lowCostCalculator = lowCostCalculator;
        public string From = "";
        public string To = "";
        public DateTime Date;
        public int Duration;

        public Package? Search(string from, string to, DateTime dateTime, int nights)
        {
            var hotels = GetHotels(to, nights, dateTime);
            var flights = GetFlights(from, to, dateTime);

            var packages = GetPackage(hotels, flights);

            return _lowCostCalculator.FindLowestPackagePrice(packages);
        }

        private IEnumerable<Package> GetPackage(IEnumerable<Hotel> hotels, IEnumerable<Flight> flights)
        {
            foreach ( var hotel in hotels )
            {
                foreach (var localAirport in hotel.LocalAirports )
                {
                    foreach (var flight in flights)
                    {
                        yield return new Package(hotel, flight, hotel.Price * hotel.Nights + flight.Price);
                    }
                }
            }
        }

        public IEnumerable<Flight> GetFlights(string destinationIATACode, string destinationAirport, DateTime date)
        {
            var results = GetData<Flight>("FlightData.json");
            List<Flight> filteredResult = new List<Flight>();

            foreach (var flight in results)
            {
                if (flight.From.Contains(destinationIATACode) &&
                    flight.To.Contains(destinationAirport) &&
                    flight.DepartureDate == date)
                {
                    filteredResult.Add(flight);
                }
            }
            return filteredResult;
        }

        public IEnumerable<Hotel> GetHotels(string destinationIATACode, int nights, DateTime date)
        {
            var results = GetData<Hotel>("HotelData.json");
            List<Hotel> filteredResult = new List<Hotel>();

            foreach ( var hotel in results)
            {
                if (hotel.LocalAirports.Contains(destinationIATACode) &&
                    hotel.Nights == nights &&
                    hotel.ArrivalDate == date)
                {
                    filteredResult.Add(hotel); 
                }
            }
            return filteredResult;
        }

        private IEnumerable<T> GetData<T>(string filename)
        {
            using (var reader = new StreamReader(GetFullFilePath(filename)))
            {
                return JsonSerializer.Deserialize<T[]>(reader.BaseStream)
                    ?? Enumerable.Empty<T>();
            }
        }

        private string GetFullFilePath(string filename)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "Data", filename);
        }
    }


}
