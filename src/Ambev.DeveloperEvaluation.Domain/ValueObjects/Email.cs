using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects
{
    /// <summary>
    /// Represents an email address in the system.
    /// This value object ensures that the email format is valid.
    /// </summary>
    public class Email
    {
        /// <summary>
        /// Gets the value of the email address.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Email"/> class.
        /// </summary>
        /// <param name="value">The email address value.</param>
        /// <exception cref="ArgumentException">Thrown when the email format is invalid.</exception>
        public Email(string value)
        {
            if (!IsValid(value)) throw new DomainException("Invalid email format");
            Value = value;
        }

        /// <summary>
        /// Validates the format of the email address.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>True if the email format is valid; otherwise, false.</returns>
        private bool IsValid(string email) => Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

        /// <summary>
        /// Returns the string representation of the email address.
        /// </summary>
        /// <returns>The email address as a string.</returns>
        public override string ToString() => Value;
    }
}