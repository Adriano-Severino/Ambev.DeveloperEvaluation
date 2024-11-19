namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; private set; }
        public decimal Discount { get; private set; }

        public SaleItem() { Id = Guid.NewGuid(); }
        public void ApplyDiscount(decimal discountPercentage) 
        { 
            Discount = UnitPrice * discountPercentage; 
        }

    }
}
