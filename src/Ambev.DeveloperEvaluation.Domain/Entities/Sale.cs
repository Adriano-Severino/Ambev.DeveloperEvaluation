using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Common;

/// <summary>
/// Represents a sale transaction.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    /// Gets or sets the sale number.
    /// </summary>
    public string SaleNumber { get; set; }

    /// <summary>
    /// Gets or sets the sale date.
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// Gets or sets the customer name.
    /// </summary>
    public string Customer { get; set; }

    /// <summary>
    /// Gets or sets the branch name.
    /// </summary>
    public string Branch { get; set; }

    /// <summary>
    /// Gets or sets the list of sale items.
    /// </summary>
    public List<SaleItem> Items { get; set; } = new();

    /// <summary>
    /// Gets the total amount of the sale.
    /// </summary>
    public decimal TotalAmount { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the sale is cancelled.
    /// </summary>
    public bool IsCancelled { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Sale"/> class.
    /// </summary>
    public Sale()
    {
        SaleDate = DateTime.UtcNow;
        IsCancelled = false;
    }

    /// <summary>
    /// Calculates the total amount of the sale.
    /// </summary>
    public void CalculateTotal()
    {
        TotalAmount = Items.Sum(item => item.TotalPrice);
    }

    /// <summary>
    /// Applies discounts to the sale items based on the quantity rules.
    /// </summary>
    public void ApplyDiscounts()
    {
        foreach (var item in Items)
        {
            if (item.Quantity >= 4 && item.Quantity < 10)
                item.ApplyDiscount(0.10m);
            else if (item.Quantity >= 10 && item.Quantity <= 20)
                item.ApplyDiscount(0.20m);
            else if (item.Quantity > 20)
                throw new InvalidOperationException("Não é possível vender acima de 20 itens idênticos.");
            else
                item.ApplyDiscount(0.00m); // Remove desconto se a quantidade for menor que 4
        }
    }

    /// <summary>
    /// Adds an item to the sale and updates the total amount.
    /// </summary>
    /// <param name="item">The sale item to add.</param>
    public void AddItem(SaleItem item)
    {
        if (item.Quantity > 20)
            throw new InvalidOperationException("Não é possível vender acima de 20 itens idênticos.");

        Items.Add(item);
        ApplyDiscounts();
        CalculateTotal();
    }

    /// <summary>
    /// Removes an item from the sale and updates the total amount.
    /// </summary>
    /// <param name="item">The sale item to remove.</param>
    public void RemoveItem(SaleItem item)
    {
        Items.Remove(item);
        ApplyDiscounts();
        CalculateTotal();
    }

    /// <summary>
    /// Cancels the sale.
    /// </summary>
    public void Cancel()
    {
        IsCancelled = true;
    }

    /// <summary>
    /// Completes the sale.
    /// </summary>
    public void Complete()
    {
        IsCancelled = false;
    }
}