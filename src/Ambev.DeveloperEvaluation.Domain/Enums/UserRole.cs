namespace Ambev.DeveloperEvaluation.Domain.Enums
{
    /// <summary>
    /// Specifies the roles that a user can have within the system.
    /// </summary>
    public enum UserRole
    {
        /// <summary>
        /// Represents no specified role.
        /// </summary>
        None = 0,

        /// <summary>
        /// Represents a customer role.
        /// </summary>
        Customer,

        /// <summary>
        /// Represents a manager role.
        /// </summary>
        Manager,

        /// <summary>
        /// Represents an admin role.
        /// </summary>
        Admin,
    }
}
