namespace HolidaySearch
{
    public class LowestCostCalculator
    {
        public Package? FindLowestPackagePrice(IEnumerable<Package> packages)
        {
            if (!packages.Any())
            {
                return null;
            } else
            {
                return packages.OrderBy(p => p.Price).First();
            }
        }
    }
}
