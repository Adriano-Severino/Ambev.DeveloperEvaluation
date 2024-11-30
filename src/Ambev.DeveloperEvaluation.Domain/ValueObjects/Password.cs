namespace Ambev.DeveloperEvaluation.Domain.ValueObjects
{
    /// <summary>
    /// Represents a password with validation and hashing.
    /// This value object ensures that the password meets specified complexity requirements.
    /// </summary>
    public class Password
    {
        /// <summary>
        /// Gets the hashed value of the password.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Password"/> class.
        /// </summary>
        /// <param name="value">The plain text password value.</param>
        /// <exception cref="ArgumentException">Thrown when the password does not meet complexity requirements.</exception>
        public Password(string value)
        {
            if (!IsValid(value)) throw new DomainException("Password does not meet complexity requirements");
            Value = HashPassword(value);
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
