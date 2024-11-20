using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events
{

    /// <summary>
    /// Event raised when an item is cancelled.
    /// </summary>
    public class ItemCancelled : IDomainEvent
    {
        public SaleItem SaleItem { get; }

        public ItemCancelled(SaleItem saleItem)
        {
            SaleItem = saleItem;
        }
    }
}
