using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    /// <summary>
    /// Event that occurs when a user is registered.
    /// </summary>
    public class UserRegisteredEvent
    {
        /// <summary>
        /// Gets the user that was registered.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRegisteredEvent"/> class.
        /// </summary>
        /// <param name="user">The user that was registered.</param>
        public UserRegisteredEvent(User user)
        {
            User = user;
        }
    }
}
