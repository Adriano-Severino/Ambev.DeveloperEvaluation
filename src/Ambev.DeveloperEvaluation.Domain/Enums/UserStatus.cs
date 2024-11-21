namespace Ambev.DeveloperEvaluation.Domain.Enums
{
    /// <summary>
    /// Specifies the status that a user can have within the system.
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// Indicates the user's status is unknown.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Indicates the user is active.
        /// </summary>
        Active,

        /// <summary>
        /// Indicates the user is inactive.
        /// </summary>
        Inactive,

        /// <summary>
        /// Indicates the user is suspended.
        /// </summary>
        Suspended
    }
}
