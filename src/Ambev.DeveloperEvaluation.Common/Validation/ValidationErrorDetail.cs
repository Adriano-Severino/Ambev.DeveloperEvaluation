using FluentValidation.Results;

namespace Ambev.DeveloperEvaluation.Common.Validation
{
    /// <summary>
    /// Represents the details of a validation error.
    /// </summary>
    public class ValidationErrorDetail
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        public string Error { get; init; } = string.Empty;

        /// <summary>
        /// Gets or sets the detailed error message.
        /// </summary>
        public string Detail { get; init; } = string.Empty;

        /// <summary>
        /// Converts a ValidationFailure to a ValidationErrorDetail.
        /// </summary>
        /// <param name="validationFailure">The validation failure.</param>
        /// <returns>A ValidationErrorDetail instance.</returns>
        public static explicit operator ValidationErrorDetail(ValidationFailure validationFailure)
        {
            return new ValidationErrorDetail
            {
                Detail = validationFailure.ErrorMessage,
                Error = validationFailure.ErrorCode
            };
        }
    }
}
