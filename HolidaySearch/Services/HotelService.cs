using HolidaySearch.Data;
using HolidaySearch.Models;

namespace HolidaySearch.Services
{
    public class HotelService
    {
        private readonly IDataLookupService _dataLookupService;

        public HotelService(IDataLookupService dataLookupService)
        {
            _dataLookupService = dataLookupService;
        }
        public IEnumerable<Hotel> GetHotels(string destinationIATACode, int nights, DateTime date)
        {
            var results = _dataLookupService.GetHotels();
            List<Hotel> filteredResult = new List<Hotel>();

            foreach (var hotel in results)
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
    }
}
