using FluentValidation.Results;

namespace Ambev.DeveloperEvaluation.Common.Validation
{
    /// <summary>
    /// Represents the detailed result of a validation process.
    /// </summary>
    public class ValidationResultDetail
    {
        /// <summary>
        /// Gets or sets a value indicating whether the validation was successful.
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Gets or sets the collection of validation errors.
        /// </summary>
        public IEnumerable<ValidationErrorDetail> Errors { get; set; } = [];

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResultDetail"/> class.
        /// </summary>
        public ValidationResultDetail()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResultDetail"/> class with a specified validation result.
        /// </summary>
        /// <param name="validationResult">The validation result to initialize with.</param>
        public ValidationResultDetail(ValidationResult validationResult)
        {
            IsValid = validationResult.IsValid;
            Errors = validationResult.Errors.Select(o => (ValidationErrorDetail)o);
        }
    }
}
