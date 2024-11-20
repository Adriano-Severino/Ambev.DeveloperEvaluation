using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData
{
    /// <summary>
    /// Provides methods for generating test data using the Bogus library.
    /// This class centralizes all test data generation to ensure consistency
    /// across test cases and provide both valid and invalid data scenarios.
    /// </summary>
    public static class SaleTestData
    {
        private static readonly Faker<Sale> SaleFaker = new Faker<Sale>()
            .RuleFor(s => s.SaleDate, f => f.Date.Past())
            .RuleFor(s => s.Customer, f => f.Person.FullName)
            .RuleFor(s => s.Branch, f => f.Company.CompanyName())
            .RuleFor(s => s.IsCancelled, f => false);

        private static readonly Faker<SaleItem> SaleItemFaker = new Faker<SaleItem>()
            .RuleFor(i => i.ProductName, f => f.Commerce.ProductName())
            .RuleFor(i => i.Quantity, f => f.Random.Number(1, 20))
            .RuleFor(i => i.UnitPrice, f => f.Finance.Amount(1, 100));

        /// <summary>
        /// Generates a valid Sale entity with randomized data.
        /// The generated sale will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <param name="includeItems">If true, generates sale items</param>
        /// <param name="itemCount">The number of items to generate</param>
        /// <returns>A valid Sale entity with randomly generated data.</returns>
        public static Sale GenerateValidSale(bool includeItems = true, int itemCount = 1)
        {
            var sale = new Sale();
            sale.SaleDate = SaleFaker.Generate().SaleDate;
            sale.Customer = SaleFaker.Generate().Customer;
            sale.Branch = SaleFaker.Generate().Branch;

            if (includeItems)
            {
                sale.Items = GenerateValidSaleItems(itemCount);
            }

            sale.CalculateTotal();
            return sale;
        }

        /// <summary>
        /// Generates a valid list of SaleItem entities with randomized data.
        /// </summary>
        /// <param name="count">The number of items to generate</param>
        /// <returns>A list of valid SaleItem entities.</returns>
        public static List<SaleItem> GenerateValidSaleItems(int count)
        {
            return SaleItemFaker.Generate(count);
        }

        /// <summary>
        /// Generates an invalid Sale entity for testing negative scenarios.
        /// </summary>
        /// <returns>An invalid Sale entity.</returns>
        public static Sale GenerateInvalidSale()
        {
            var sale = new Sale();
            sale.SaleDate = DateTime.MinValue; // Invalid: unrealistic date
            sale.Customer = ""; // Invalid: empty
            sale.Branch = ""; // Invalid: empty
            sale.Items = new List<SaleItem>(); // Invalid: no items
            sale.CalculateTotal();
            return sale;
        }
    }
}
