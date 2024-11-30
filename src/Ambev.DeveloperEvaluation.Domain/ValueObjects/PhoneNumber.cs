using System.Text.RegularExpressions;

namespace Ambev.DeveloperEvaluation.Domain.ValueObjects
{
    /// <summary>
    /// Represents a phone number with validation.
    /// This value object ensures that the phone number format is valid.
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Gets the value of the phone number.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneNumber"/> class.
        /// </summary>
        /// <param name="value">The phone number value.</param>
        /// <exception cref="ArgumentException">Thrown when the phone number format is invalid.</exception>
        public PhoneNumber(string value)
        {
            if (!IsValid(value)) throw new DomainException("Invalid phone number format");
            Value = value;
        }

        /// <summary>
        /// Validates the format of the phone number.
        /// </summary>
        /// <param name="phone">The phone number to validate.</param>
        /// <returns>True if the phone number format is valid; otherwise, false.</returns>
        private bool IsValid(string phone) => Regex.IsMatch(phone, @"^\+?[1-9]\d{1,14}$");

        /// <summary>
        /// Returns the string representation of the phone number.
        /// </summary>
        /// <returns>The phone number as a string.</returns>
        public override string ToString() => Value;
    }
}