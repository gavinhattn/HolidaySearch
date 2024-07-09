namespace HolidaySearch.Models
{
    public class Package
    {
        public Package(Hotel hotel, Flight flight, int price)
        {
            Hotel = hotel;
            Flight = flight;
            Price = price;
        }
        public Hotel Hotel { get; }
        public Flight Flight { get; }
        public int Price { get; }

    }
}