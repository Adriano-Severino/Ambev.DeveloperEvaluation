/// <summary>
/// Represents the response model for a sale item.
/// </summary>
public class CreateSaleItemResult
{
    /// <summary>
    /// Gets or sets the product name.
    /// </summary>
    /// <value>The name of the product.</value>
    public string ProductName { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product.
    /// </summary>
    /// <value>The quantity of the product.</value>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the product.
    /// </summary>
    /// <value>The unit price of the product.</value>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the discount applied to the product.
    /// </summary>
    /// <value>The discount applied to the product.</value>
    public decimal Discount { get; set; }

    /// <summary>
    /// Gets or sets the total price of the product after discount.
    /// </summary>
    /// <value>The total price of the product after discount.</value>
    public decimal TotalPrice { get; set; }
}