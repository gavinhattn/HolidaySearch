using HolidaySearch.Data;
using HolidaySearch.Models;

namespace HolidaySearch.Services
{
    public class FlightService
    {

        private readonly IDataLookupService _dataLookupService;

        public FlightService(IDataLookupService dataLookupService)
        {
           _dataLookupService = dataLookupService;
        }

        public IEnumerable<Flight> GetFlights(string destinationIATACode, string destinationAirport, DateTime date)
        {
            var results = _dataLookupService.GetFlights();
            List <Flight> filteredResult = new List<Flight>();

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
    }
}
