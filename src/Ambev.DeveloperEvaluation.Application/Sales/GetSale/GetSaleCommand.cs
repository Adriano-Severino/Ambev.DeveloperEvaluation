using MediatR;
using System;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Command for retrieving a sale.
/// </summary>
public class GetSaleCommand : IRequest<GetSaleResult>
{
    /// <summary>
    /// Gets or sets the unique identifier of the sale.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Initializes a new instance of the GetSaleCommand.
    /// </summary>
    /// <param name="id">The unique identifier of the sale to retrieve.</param>
    public GetSaleCommand(Guid id)
    {
        Id = id;
    }
}
