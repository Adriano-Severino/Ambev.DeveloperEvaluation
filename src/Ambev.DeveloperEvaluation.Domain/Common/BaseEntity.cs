using System.Collections.Generic;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Domain.Common
{
    /// <summary>
    /// BaseEntity
    /// </summary>
    public class BaseEntity : IComparable<BaseEntity>
    {
        private readonly List<INotification> _domainEvents = new List<INotification>();

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Domain Events
        /// </summary>
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

        /// <summary>
        /// Validation Error Detail
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<ValidationErrorDetail>> ValidateAsync()
        {
            return Validator.ValidateAsync(this);
        }

        /// <summary>
        /// Commpare To
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(BaseEntity? other)
        {
            if (other == null)
            {
                return 1;
            }

            return other.Id.CompareTo(Id);
        }

        /// <summary>
        /// Adds a domain event to the entity
        /// </summary>
        /// <param name="eventItem">The domain event to add</param>
        protected void AddDomainEvent(INotification eventItem)
        {
            _domainEvents.Add(eventItem);
        }

        /// <summary>
        /// Clears all domain events from the entity
        /// </summary>
        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
