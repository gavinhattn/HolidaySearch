namespace HolidaySearch.Tests

{

    using FluentAssertions;

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
    }
}