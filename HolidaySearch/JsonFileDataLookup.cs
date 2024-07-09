using HolidaySearch.Data;
using HolidaySearch.Models;
using System.Text.Json;

namespace HolidaySearch
{
    public class JsonFileDataLookup : IDataLookupService
    {
        private string Flights = "FlightData.json";
        private string Hotels = "HotelData.json";
        public IEnumerable<Flight> GetFlights() => GetData<Flight>(Flights);
        public IEnumerable<Hotel> GetHotels() => GetData<Hotel>(Hotels);

        private IEnumerable<T> GetData<T>(string filename)
        {
            using (var reader = new StreamReader(GetFullFilePath(filename)))
                return JsonSerializer.Deserialize<T[]>(reader.BaseStream)
                    ?? Enumerable.Empty<T>();
        }

        private string GetFullFilePath(string filename) =>
            Path.Combine(Directory.GetCurrentDirectory(), "Data", filename);
    }
}
