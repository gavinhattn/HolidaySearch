using HolidaySearch.Models;

namespace HolidaySearch.Data
{
    public interface IDataLookupService
    {
        IEnumerable<Hotel> GetHotels();
        IEnumerable<Flight> GetFlights();
    }
}
