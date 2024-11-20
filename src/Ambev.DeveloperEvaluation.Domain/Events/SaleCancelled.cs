using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    /// <summary>
    /// Event raised when a sale is cancelled.
    /// </summary>
    public class SaleCancelled : IDomainEvent
    {
        public Sale Sale { get; }

        public SaleCancelled(Sale sale)
        {
            Sale = sale;
        }
    }
}
