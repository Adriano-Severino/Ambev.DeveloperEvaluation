﻿namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleItemCommand
    {
        public string ProductName { get; set; } = string.Empty; public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

}
