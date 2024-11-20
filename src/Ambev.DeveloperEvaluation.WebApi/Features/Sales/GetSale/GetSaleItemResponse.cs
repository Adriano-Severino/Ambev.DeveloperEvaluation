namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public class GetSaleItemResponse
    {
        public Guid Id { get; set; }

        /// <summary>
        /// The product name.
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// The quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The unit price.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// The total price.
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// The discount.
        /// </summary>
        public decimal Discount { get; set; }
    }
}
