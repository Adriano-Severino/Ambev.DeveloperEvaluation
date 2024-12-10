using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects
{
    /// <summary>
    /// Represents a password with validation and hashing.
    /// This value object ensures that the password meets specified complexity requirements.
    /// </summary>
    public class Password
    {
        /// <summary>
        /// Creates a new Password instance from an existing hash value.
        /// Used internally by Entity Framework for database operations.
        /// </summary>
        /// <param name="hashedValue">The pre-hashed password value.</param>
        private Password(string hashedValue)
        {
            Value = hashedValue;
        }

        /// <summary>
        /// Creates a Password instance from an existing hash.
        /// Used by Entity Framework when reading from the database.
        /// </summary>
        /// <param name="hashedValue">The pre-hashed password value.</param>
        /// <returns>A new Password instance containing the hash.</returns>
        public static Password CreateFromHash(string hashedValue)
        {
            return new Password(hashedValue);
        }


        /// <summary>
        /// Gets the hashed value of the password.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Creates a new Password instance from a plain text password.
        /// Validates password complexity and creates a secure hash.
        /// </summary>
        /// <param name="value">The plain text password to hash.</param>
        /// <param name="passwordHasher">The service used to hash the password.</param>
        /// <exception cref="DomainException">Thrown when password complexity requirements are not met.</exception>
        public Password(string value, IPasswordHasher passwordHasher)
        {
            if (!IsValid(value)) throw new DomainException("Password does not meet complexity requirements");
            Value = passwordHasher.HashPassword(value);
        }

        /// <summary>
        /// Validates the complexity of the password.
        /// </summary>
        /// <param name="password">The plain text password to validate.</param>
        /// <returns>True if the password meets complexity requirements; otherwise, false.</returns>
        private bool IsValid(string password) => 
            password.Length >= 8 &&
            password.Any(char.IsUpper) &&
            password.Any(char.IsLower) &&
            password.Any(char.IsDigit) &&
            password.Any(ch => !char.IsLetterOrDigit(ch));

        /// <summary>
        /// Hashes the plain text password using a secure algorithm.
        /// </summary>
        /// <param name="password">The plain text password to hash.</param>
        /// <returns>The hashed password.</returns>
        private string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);

        /// <summary>
        /// Returns a masked representation of the password.
        /// </summary>
        /// <returns>A string containing masked characters.</returns>
        public override string ToString() => "******";
    }
}
