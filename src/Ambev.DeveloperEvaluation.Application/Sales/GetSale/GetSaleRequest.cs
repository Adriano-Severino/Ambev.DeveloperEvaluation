using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Represents a request to get a sale by its ID.
/// </summary>
public class GetSaleRequest
{
    /// <summary>
    /// Gets or sets the unique identifier of the sale.
    /// </summary>
    public Guid Id { get; set; }
}
