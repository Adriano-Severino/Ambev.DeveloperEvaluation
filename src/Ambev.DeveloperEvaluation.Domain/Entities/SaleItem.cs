using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; private set; }
        public decimal Discount { get; private set; }

        public SaleItem()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Applies a discount and calculates the total price.
        /// </summary>
        /// <param name="discountPercentage">The discount percentage to apply.</param>
        public void ApplyDiscount(decimal discountPercentage)
        {
            Discount = discountPercentage;
            CalculateTotalPrice();
        }

        /// <summary>
        /// Calculates the total price of the item.
        /// </summary>
        public void CalculateTotalPrice()
        {
            TotalPrice = UnitPrice * Quantity * (1 - Discount);
        }
    }
}
