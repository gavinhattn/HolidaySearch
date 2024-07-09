using System.Text.Json;
using HolidaySearch.Models;
using HolidaySearch.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HolidaySearch
{
    public class HolidaySearch
    {
        private readonly LowestCostCalculator _lowCostCalculator;
        private readonly HotelService _hotelService;
        private readonly FlightService _FlightService;

        public HolidaySearch(LowestCostCalculator lowCostCalculator, HotelService hotelService, FlightService flightService)
        {
            _lowCostCalculator = lowCostCalculator;
            _hotelService = hotelService;
            _FlightService = flightService;
        }

        public Package? Search(string from, string to, DateTime dateTime, int nights)
        {
            IEnumerable<Hotel> hotels = _hotelService.GetHotels(to, nights, dateTime);
            IEnumerable<Flight> flights = _FlightService.GetFlights(from, to, dateTime);

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
    }
}
