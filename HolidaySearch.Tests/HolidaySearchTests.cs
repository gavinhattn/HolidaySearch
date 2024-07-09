using FluentAssertions;
using HolidaySearch.Services;

namespace HolidaySearch.Tests
{
    public class HolidaySearchTests
    {
        private readonly LowestCostCalculator _lowestCostCalculator;
        private readonly JsonFileDataLookup _dataLookupService;
        private readonly HotelService _hotelService;
        private readonly FlightService _flightService;

        public HolidaySearchTests()
        {
            _lowestCostCalculator = new LowestCostCalculator();
            _dataLookupService = new JsonFileDataLookup();
            _hotelService = new HotelService(_dataLookupService);
            _flightService = new FlightService(_dataLookupService);
        }

        [Fact]
        public void GivenHolidaySearch_WhenSearch_ThenReturnShouldNotBeEmpty()
        {
            //Given
            var subject = new HolidaySearch(_lowestCostCalculator, _hotelService, _flightService);

            //When
            var result = subject.Search("MAN", "AGP", DateTime.Parse("2023-07-01"), 7);

            //Then
            result.Should().NotBeNull();
        }

        [Theory]
        [InlineData("MAN", "AGP", "2023-07-01", 7, 2, 9)]
        [InlineData("LTN", "PMI", "2023-06-15", 10, 4, 5)]
        [InlineData("MAN", "LPA", "2022-11-10", 14, 7, 6)]
        public void GivenHolidaySearch_WhenSearch_ThenReturnExpectedPackageReturns(string from, string to, string date, int nights,
            int expectedFlightId, int expectedHotelId)
        {
            //Given
            var subject = new HolidaySearch(_lowestCostCalculator, _hotelService, _flightService);

            //When
            var result = subject.Search(from, to, DateTime.Parse(date), nights);

            //Then
            result.Should().NotBeNull();
            result.Flight.Id.Should().Be(expectedFlightId);
            result.Hotel.Id.Should().Be(expectedHotelId);
        }

        [Fact]
        public void GivenHolidaySearch_ThatIsNotInOurData_WhenSearch_ThenReturnPackageShouldBeNull()
        {
            //Given
            var subject = new HolidaySearch(_lowestCostCalculator, _hotelService, _flightService);

            //When
            var result = subject.Search("ZRH", "AGP", DateTime.Parse("2023-07-01"), 3);

            //Then
            result.Should().BeNull();
        }
    }
}