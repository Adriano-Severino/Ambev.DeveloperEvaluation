namespace Ambev.DeveloperEvaluation.Domain.Specifications
{
    /// <summary>
    /// Interface for defining specifications.
    /// </summary>
    /// <typeparam name="T">The type of entity to which the specification applies.</typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Checks if the specified entity satisfies the specification.
        /// </summary>
        /// <param name="entity">The entity to check.</param>
        /// <returns>True if the entity satisfies the specification, otherwise false.</returns>
        bool IsSatisfiedBy(T entity);
    }
}
