using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Common.Pagination;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    /// <summary>
    /// Command for retrieving all sales with pagination.
    /// </summary>
    public class GetAllSalesCommand : IRequest<PaginatedList<GetAllSalesResult>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
