namespace HolidaySearch.Tests

{

    using FluentAssertions;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public class HolidaySearchTests
    {
        [Fact]
        public void GivenHolidaySearch_WhenSearch_ThenReturnShouldNotBeEmpty()
        {
            //Given
            var subject = new HolidaySearch();

            //When
            var result = subject.Search();

            //Then
            result.Should().NotBeNull();
        }

        [Fact]
        public void GivenHolidaySearch_WhenSearch_ThenReturnExpectedPackageReturns()
        {
            //Given
            var subject = new HolidaySearch();

            //When
            var result = subject.Search();

            //Then
            result.Should().NotBeNull();
            result.Flight.Id.Should().Be("");
            result.Hotel.Id.Should().Be("");
        }
    }
}