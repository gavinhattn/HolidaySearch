
using System;
using System.ComponentModel;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HolidaySearch
{
    public class HolidaySearch
    {
        public IEnumerable<Hotel> Search()
        {
            var hotels = GetHotels();
            //var flights = GetFlights();

            return hotels;
        }

        //public IEnumerable<Flight> GetFlights()
        //{
        //    var results = GetData<Flight>("FlightData.json");
        //    return results;
        //}

        public IEnumerable<Hotel> GetHotels()
        {
            var results = GetData<Hotel>("HotelData.json");
            return results;
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
