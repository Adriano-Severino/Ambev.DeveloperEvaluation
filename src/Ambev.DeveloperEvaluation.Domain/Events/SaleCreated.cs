using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    /// <summary>
    /// Event raised when a sale is created.
    /// </summary>
    public class SaleCreated : IDomainEvent
    {
        public Sale Sale { get; }

        public SaleCreated(Sale sale)
        {
            Sale = sale;
        }
    }

}
