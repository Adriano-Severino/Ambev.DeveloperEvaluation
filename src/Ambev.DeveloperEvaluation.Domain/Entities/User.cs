using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a user in the system with authentication and profile information.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class User : BaseEntity, IUser
    {
        /// <summary>
        /// Gets the user's full name.
        /// Must not be null or empty and should contain both first and last names.
        /// </summary>
        public string Username { get; private set; } = string.Empty;

        /// <summary>
        /// Gets the user's email address.
        /// Must be a valid email format and is used as a unique identifier for authentication.
        /// </summary>
        public Email Email { get; private set; }

        /// <summary>
        /// Gets the user's phone number.
        /// Must be a valid phone number format following the pattern (XX) XXXXX-XXXX.
        /// </summary>
        public PhoneNumber Phone { get; private set; }

        /// <summary>
        /// Gets the hashed password for authentication.
        /// Password must meet security requirements: minimum 8 characters, at least one uppercase letter,
        /// one lowercase letter, one number, and one special character.
        /// </summary>
        public Password Password { get; private set; }

        /// <summary>
        /// Gets the user's role in the system.
        /// Determines the user's permissions and access levels.
        /// </summary>
        public UserRole Role { get; private set; }

        /// <summary>
        /// Gets the user's current status.
        /// Indicates whether the user is active, inactive, or blocked in the system.
        /// </summary>
        public UserStatus Status { get; private set; }

        /// <summary>
        /// Gets the date and time when the user was created.
        /// </summary>
        public DateTime CreatedAt { get; private set; }

        /// <summary>
        /// Gets the date and time of the last update to the user's information.
        /// </summary>
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>
        /// Gets the unique identifier of the user.
        /// </summary>
        /// <returns>The user's ID as a string.</returns>
        string IUser.Id => Id.ToString();

        /// <summary>
        /// Gets the username.
        /// </summary>
        /// <returns>The username.</returns>
        string IUser.Username => Username;

        /// <summary>
        /// Gets the user's role in the system.
        /// </summary>
        /// <returns>The user's role as a string.</returns>
        string IUser.Role => Role.ToString();

        /// <summary>
        /// Initializes a new instance of the User class.
        /// </summary>
        public User(string username, Email email, PhoneNumber phone, Password password, UserRole role)
        {
            Username = username;
            Email = email;
            Phone = phone;
            Password = password;
            Role = role;
            Status = UserStatus.Active;
            CreatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Performs validation of the user entity using the UserValidator rules.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">Username format and length</list>
        /// <list type="bullet">Email format</list>
        /// <list type="bullet">Phone number format</list>
        /// <list type="bullet">Password complexity requirements</list>
        /// <list type="bullet">Role validity</list>
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new UserValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        /// <summary>
        /// Activates the user account.
        /// Changes the user's status to Active.
        /// </summary>
        public void Activate()
        {
            Status = UserStatus.Active;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Deactivates the user account.
        /// Changes the user's status to Inactive.
        /// </summary>
        public void Deactivate()
        {
            Status = UserStatus.Inactive;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Blocks the user account.
        /// Changes the user's status to Blocked.
        /// </summary>
        public void Suspend()
        {
            Status = UserStatus.Suspended;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Updates the user's password.
        /// </summary>
        /// <param name="password">The new password.</param>
        public void SetPassword(Password password)
        {
            Password = password;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Sets the user's status.
        /// </summary>
        /// <param name="status">The new status.</param>
        public void SetStatus(UserStatus status)
        {
            Status = status;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Sets the user's role.
        /// </summary>
        /// <param name="role">The new role.</param>
        public void SetRole(UserRole role)
        {
            Role = role;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Sets the user's email.
        /// </summary>
        /// <param name="email">The new email.</param>
        public void SetEmail(Email email)
        {
            Email = email;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Sets the user's phone number.
        /// </summary>
        /// <param name="phone">The new phone number.</param>
        public void SetPhone(PhoneNumber phone)
        {
            Phone = phone;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
