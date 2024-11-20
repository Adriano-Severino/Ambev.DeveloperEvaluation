using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Ambev.DeveloperEvaluation.Domain.Common;

/// <summary>
/// Represents a sale transaction.
/// </summary>
public class Sale : BaseEntity
{
    private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Gets or sets the sale number.
    /// </summary>
    public string SaleNumber { get; private set; }

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
        SaleNumber = GenerateSaleNumber();
        IsCancelled = false;
    }

    /// <summary>
    /// Generates a random sale number (SKU) with letters and numbers.
    /// </summary>
    /// <returns>A unique sale number.</returns>
    private string GenerateSaleNumber()
    {
        var random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 10)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    private void AddDomainEvent(IDomainEvent eventItem)
    {
        _domainEvents.Add(eventItem);
    }

    /// <summary>
    /// Creates the sale and triggers a SaleCreated event.
    /// </summary>
    public void Create()
    {
        AddDomainEvent(new SaleCreated(this));
    }

    /// <summary>
    /// Modifies the sale and triggers a SaleModified event.
    /// </summary>
    public void Modify()
    {
        AddDomainEvent(new SaleModified(this));
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
                throw new DomainException("Não é possível vender acima de 20 itens idênticos.");
            else
                item.ApplyDiscount(0.00m); // Remove desconto se a quantidade for menor que 4

            item.CalculateTotalPrice(); // Atualiza o preço total do item
        }
    }

    /// <summary>
    /// Adds an item to the sale and updates the total amount.
    /// </summary>
    /// <param name="item">The sale item to add.</param>
    public void AddItem(SaleItem item)
    {
        if (item.Quantity > 20)
            throw new DomainException("Não é possível vender acima de 20 itens idênticos.");

        Items.Add(item);
        ApplyDiscounts();
        CalculateTotal();
        Modify();
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
        AddDomainEvent(new ItemCancelled(item));
    }

    /// <summary>
    /// Cancels the sale and triggers a SaleCancelled event.
    /// </summary>
    public void Cancel()
    {
        IsCancelled = true;
        AddDomainEvent(new SaleCancelled(this));
    }

    /// <summary>
    /// Completes the sale.
    /// </summary>
    public void Complete()
    {
        IsCancelled = false;
    }
}
