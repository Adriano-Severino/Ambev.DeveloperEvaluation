using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using NSubstitute;
using Xunit;
using System;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    /// <summary>
    /// Contains unit tests for the Sale entity class.
    /// Tests cover event dispatching and validation scenarios.
    /// </summary>
    public class SaleTests
    {
        [Fact(DisplayName = "10% discount should be applied for 4-9 identical items")]
        public void Given_4To9IdenticalItems_When_Calculated_Then_ShouldApply10PercentDiscount()
        {
            var sale = SaleTestData.GenerateValidSale(false);
            var item = new SaleItem { ProductName = "Product", Quantity = 5, UnitPrice = 100 };
            sale.AddItem(item);

            sale.ApplyDiscounts();
            sale.CalculateTotal();

            Assert.Equal(450, sale.TotalAmount);
        }

        [Fact(DisplayName = "20% discount should be applied for 10-20 identical items")]
        public void Given_10To20IdenticalItems_When_Calculated_Then_ShouldApply20PercentDiscount()
        {
            var sale = SaleTestData.GenerateValidSale(false);
            var item = new SaleItem { ProductName = "Product", Quantity = 10, UnitPrice = 100 };
            sale.AddItem(item);

            sale.ApplyDiscounts();
            sale.CalculateTotal();

            Assert.Equal(800, sale.TotalAmount);
        }

        [Fact(DisplayName = "Exception should be thrown for purchases above 20 identical items")]
        public void Given_Above20IdenticalItems_When_Added_Then_ShouldThrowException()
        {
            var sale = SaleTestData.GenerateValidSale(false);
            var item = new SaleItem { ProductName = "Product", Quantity = 21, UnitPrice = 100 };

            Assert.Throws<DomainException>(() => sale.AddItem(item));
        }

        [Fact(DisplayName = "No discount should be applied for purchases below 4 identical items")]
        public void Given_Below4IdenticalItems_When_Calculated_Then_ShouldNotApplyDiscount()
        {
            var sale = SaleTestData.GenerateValidSale(false);
            var item = new SaleItem { ProductName = "Product", Quantity = 3, UnitPrice = 100 };
            sale.AddItem(item);

            sale.ApplyDiscounts();
            sale.CalculateTotal();

            Assert.Equal(300, sale.TotalAmount);
        }
    }
}
