using System;
using System.Collections.Generic;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// API response model for CreateSale operation.
/// </summary>
public class CreateSaleResponse
{
    /// <summary>
    /// The unique identifier of the created sale.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The sale number.
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    /// The sale date.
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// The customer name.
    /// </summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// The branch name.
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// The total amount of the sale.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// The list of sale items.
    /// </summary>
    public List<CreateSaleItemResponse> Items { get; set; } = new();
}


