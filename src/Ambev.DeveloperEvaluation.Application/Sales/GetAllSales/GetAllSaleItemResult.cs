namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    public class GetAllSaleItemResult
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
