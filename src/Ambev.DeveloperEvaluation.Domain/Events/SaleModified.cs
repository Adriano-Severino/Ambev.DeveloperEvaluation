using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    /// <summary>
    /// Event raised when a sale is modified.
    /// </summary>
    public class SaleModified : IDomainEvent
    {
        public Sale Sale { get; }

        public SaleModified(Sale sale)
        {
            Sale = sale;
        }
    }
}
