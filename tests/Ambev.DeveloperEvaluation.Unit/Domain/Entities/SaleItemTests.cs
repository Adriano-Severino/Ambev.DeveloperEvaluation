using Xunit;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    /// <summary>
    /// Contains unit tests for the SaleItem entity class.
    /// Tests cover discount application and total price calculation scenarios.
    /// </summary>
    public class SaleItemTests
    {
        /// <summary>
        /// Tests that the total price is correctly calculated without any discount.
        /// </summary>
        [Fact(DisplayName = "Total price should be correctly calculated without any discount")]
        public void Given_UnitPriceAndQuantity_When_NoDiscountApplied_Then_TotalPriceShouldBeCalculatedCorrectly()
        {
            // Arrange
            var saleItem = new SaleItem
            {
                ProductName = "Product",
                Quantity = 5,
                UnitPrice = 100
            };

            // Act
            saleItem.CalculateTotalPrice();

            // Assert
            Assert.Equal(500, saleItem.TotalPrice);
        }

        /// <summary>
        /// Tests that the total price is correctly calculated with a 10% discount.
        /// </summary>
        [Fact(DisplayName = "Total price should be correctly calculated with a 10% discount")]
        public void Given_UnitPriceAndQuantity_When_10PercentDiscountApplied_Then_TotalPriceShouldBeCalculatedCorrectly()
        {
            // Arrange
            var saleItem = new SaleItem
            {
                ProductName = "Product",
                Quantity = 5,
                UnitPrice = 100
            };

            // Act
            saleItem.ApplyDiscount(0.10m);

            // Assert
            Assert.Equal(450, saleItem.TotalPrice);
        }

        /// <summary>
        /// Tests that the total price is correctly calculated with a 20% discount.
        /// </summary>
        [Fact(DisplayName = "Total price should be correctly calculated with a 20% discount")]
        public void Given_UnitPriceAndQuantity_When_20PercentDiscountApplied_Then_TotalPriceShouldBeCalculatedCorrectly()
        {
            // Arrange
            var saleItem = new SaleItem
            {
                ProductName = "Product",
                Quantity = 10,
                UnitPrice = 100
            };

            // Act
            saleItem.ApplyDiscount(0.20m);

            // Assert
            Assert.Equal(800, saleItem.TotalPrice);
        }

        /// <summary>
        /// Tests that applying a discount updates the discount percentage.
        /// </summary>
        [Fact(DisplayName = "Applying a discount should update the discount percentage")]
        public void Given_DiscountPercentage_When_DiscountApplied_Then_DiscountShouldBeUpdated()
        {
            // Arrange
            var saleItem = new SaleItem
            {
                ProductName = "Product",
                Quantity = 5,
                UnitPrice = 100
            };

            // Act
            saleItem.ApplyDiscount(0.15m);

            // Assert
            Assert.Equal(0.15m, saleItem.Discount);
        }

        /// <summary>
        /// Tests that the total price is correctly recalculated when the discount is removed.
        /// </summary>
        [Fact(DisplayName = "Total price should be correctly recalculated when the discount is removed")]
        public void Given_UnitPriceAndQuantity_When_DiscountRemoved_Then_TotalPriceShouldBeRecalculatedCorrectly()
        {
            // Arrange
            var saleItem = new SaleItem
            {
                ProductName = "Product",
                Quantity = 5,
                UnitPrice = 100
            };

            // Act
            saleItem.ApplyDiscount(0.10m); // Apply 10% discount
            saleItem.ApplyDiscount(0.00m); // Remove discount

            // Assert
            Assert.Equal(500, saleItem.TotalPrice);
        }

        /// <summary>
        /// Tests that the default discount is 0 when a SaleItem is created.
        /// </summary>
        [Fact(DisplayName = "Default discount should be 0 when a SaleItem is created")]
        public void When_SaleItemCreated_Then_DefaultDiscountShouldBeZero()
        {
            // Arrange & Act
            var saleItem = new SaleItem();

            // Assert
            Assert.Equal(0.00m, saleItem.Discount);
        }
    }
}
