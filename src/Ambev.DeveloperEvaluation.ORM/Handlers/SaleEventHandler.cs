using Ambev.DeveloperEvaluation.Domain.Events;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Infrastructure.Handlers
{
    public class SaleEventHandler :
        INotificationHandler<SaleCreated>,
        INotificationHandler<SaleModified>,
        INotificationHandler<SaleCancelled>,
        INotificationHandler<ItemCancelled>
    {
        private readonly ILogger<SaleEventHandler> _logger;
        private readonly IMemoryCache _memoryCache;

        public SaleEventHandler(ILogger<SaleEventHandler> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public Task Handle(SaleCreated notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"SaleCreated event: {notification.Sale.SaleNumber}");
            _memoryCache.Set($"SaleCreated:{notification.Sale.SaleNumber}", notification, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(10)
            });
            return Task.CompletedTask;
        }

        public Task Handle(SaleModified notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"SaleModified event: {notification.Sale.SaleNumber}");
            _memoryCache.Set($"SaleModified:{notification.Sale.SaleNumber}", notification, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(10)
            });
            return Task.CompletedTask;
        }

        public Task Handle(SaleCancelled notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"SaleCancelled event: {notification.Sale.SaleNumber}");
            _memoryCache.Set($"SaleCancelled:{notification.Sale.SaleNumber}", notification, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(10)
            });
            return Task.CompletedTask;
        }

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
