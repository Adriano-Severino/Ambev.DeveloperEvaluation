namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleItemResponse
    {
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
    }
}
