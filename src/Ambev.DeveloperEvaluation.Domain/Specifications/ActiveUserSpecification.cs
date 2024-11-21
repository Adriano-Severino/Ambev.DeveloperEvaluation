using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Specifications
{
    /// <summary>
    /// Specification for determining if a user is active.
    /// </summary>
    public class ActiveUserSpecification : ISpecification<User>
    {
        /// <summary>
        /// Checks if the specified user satisfies the active status condition.
        /// </summary>
        /// <param name="user">The user to check.</param>
        /// <returns>True if the user is active, otherwise false.</returns>
        public bool IsSatisfiedBy(User user)
        {
            return user.Status == UserStatus.Active;
        }
    }
}
