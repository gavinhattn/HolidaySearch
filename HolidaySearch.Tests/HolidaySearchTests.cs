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

        [Fact]
        public void GivenHolidaySearch_WhenSearch_ThenReturnExpectedPackageReturns()
        {
            //Given
            var subject = new HolidaySearch(_lowestCostCalculator, _hotelService, _flightService);

            //When
            var result = subject.Search("MAN", "AGP", DateTime.Parse("2023-07-01"), 7);

            //Then
            result.Should().NotBeNull();
            result.Flight.Id.Should().Be(2);
            result.Hotel.Id.Should().Be(9);
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