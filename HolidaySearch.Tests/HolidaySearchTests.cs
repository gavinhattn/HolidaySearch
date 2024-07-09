namespace HolidaySearch.Tests

{

    using FluentAssertions;

    public class HolidaySearchTests
    {

        [Fact]
        public void GivenHolidaySearch_WhenSearch_ThenReturnShouldNotBeEmpty()
        {
            //Given
            var costCalc = new LowestCostCalculator();
            var subject = new HolidaySearch(costCalc);

            //When
            var result = subject.Search("MAN", "AGP", DateTime.Parse("2023-07-01"), 7);

            //Then
            result.Should().NotBeNull();
        }

        [Fact]
        public void GivenHolidaySearch_WhenSearch_ThenReturnExpectedPackageReturns()
        {
            //Given
            var costCalc = new LowestCostCalculator();
            var subject = new HolidaySearch(costCalc);

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
            var costCalc = new LowestCostCalculator();
            var subject = new HolidaySearch(costCalc);

            //When
            var result = subject.Search("ZRH", "AGP", DateTime.Parse("2023-07-01"), 3);

            //Then
            result.Should().BeNull();
        }
    }
}