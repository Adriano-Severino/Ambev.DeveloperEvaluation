namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Represents the response returned after successfully creating a new sale.
    /// </summary>
    /// <remarks>
    /// This response contains the unique identifier of the newly created sale,
    /// and details about the sale, such as sale number, date, customer, branch,
    /// total amount, items, and cancellation status.
    /// </remarks>
    public class CreateSaleResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created sale.
        /// </summary>
        /// <value>A GUID that uniquely identifies the created sale in the system.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the sale number.
        /// </summary>
        /// <value>The unique sale number.</value>
        public string SaleNumber { get; set; }

        /// <summary>
        /// Gets or sets the date when the sale was made.
        /// </summary>
        /// <value>The date of the sale.</value>
        public DateTime SaleDate { get; set; }

        /// <summary>
        /// Gets or sets the customer name.
        /// </summary>
        /// <value>The name of the customer.</value>
        public string Customer { get; set; }

        /// <summary>
        /// Gets or sets the branch where the sale was made.
        /// </summary>
        /// <value>The branch location.</value>
        public string Branch { get; set; }

        /// <summary>
        /// Gets or sets the total sale amount.
        /// </summary>
        /// <value>The total amount for the sale.</value>
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the list of sale items.
        /// </summary>
        /// <value>The list of items in the sale.</value>
        public List<CreateSaleItemResult> Items { get; set; } = new();

        /// <summary>
        /// Gets or sets a value indicating whether the sale is cancelled.
        /// </summary>
        /// <value>True if the sale is cancelled, otherwise false.</value>
        public bool IsCancelled { get; set; }
    }
}
