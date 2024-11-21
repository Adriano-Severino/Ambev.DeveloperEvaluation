using Ambev.DeveloperEvaluation.Domain.Events;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Infrastructure.Handlers
{
    /// <summary>
    /// Handler for sale events, including SaleCreated, SaleModified, SaleCancelled, and ItemCancelled.
    /// </summary>
    public class SaleEventHandler :
        INotificationHandler<SaleCreated>,
        INotificationHandler<SaleModified>,
        INotificationHandler<SaleCancelled>,
        INotificationHandler<ItemCancelled>
    {
        private readonly ILogger<SaleEventHandler> _logger;
        private readonly IMemoryCache _memoryCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="SaleEventHandler"/> class.
        /// </summary>
        /// <param name="logger">The logger instance.</param>
        /// <param name="memoryCache">The memory cache instance.</param>
        public SaleEventHandler(ILogger<SaleEventHandler> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// Handles the SaleCreated event.
        /// </summary>
        /// <param name="notification">The event notification.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A completed task.</returns>
        public Task Handle(SaleCreated notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"SaleCreated event: {notification.Sale.SaleNumber}");
            _memoryCache.Set($"SaleCreated:{notification.Sale.SaleNumber}", notification, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(10)
            });
            return Task.CompletedTask;
        }

        /// <summary>
        /// Handles the SaleModified event.
        /// </summary>
        /// <param name="notification">The event notification.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A completed task.</returns>
        public Task Handle(SaleModified notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"SaleModified event: {notification.Sale.SaleNumber}");
            _memoryCache.Set($"SaleModified:{notification.Sale.SaleNumber}", notification, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(10)
            });
            return Task.CompletedTask;
        }

        /// <summary>
        /// Handles the SaleCancelled event.
        /// </summary>
        /// <param name="notification">The event notification.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A completed task.</returns>
        public Task Handle(SaleCancelled notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"SaleCancelled event: {notification.Sale.SaleNumber}");
            _memoryCache.Set($"SaleCancelled:{notification.Sale.SaleNumber}", notification, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(10)
            });
            return Task.CompletedTask;
        }

        /// <summary>
        /// Handles the ItemCancelled event.
        /// </summary>
        /// <param name="notification">The event notification.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A completed task.</returns>
        public Task Handle(ItemCancelled notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"ItemCancelled event: {notification.SaleItem.ProductName}");
            _memoryCache.Set($"ItemCancelled:{notification.SaleItem.ProductName}", notification, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(10)
            });
            return Task.CompletedTask;
        }
    }
}
