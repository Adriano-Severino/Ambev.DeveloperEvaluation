using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents an item in a sale.
    /// </summary>
    public class SaleItem : BaseEntity
    {
        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the quantity of the product.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets the total price of the sale item.
        /// </summary>
        public decimal TotalPrice { get; private set; }

        /// <summary>
        /// Gets the discount applied to the sale item.
        /// </summary>
        public decimal Discount { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleItem"/> class.
        /// </summary>
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
