using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    /// <summary>
    /// Validator for validating phone numbers.
    /// </summary>
    public class PhoneValidator : AbstractValidator<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PhoneValidator"/> class.
        /// </summary>
        public PhoneValidator()
        {
            RuleFor(phone => phone)
                .NotEmpty().WithMessage("The phone cannot be empty.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("The phone format is not valid.");
        }
    }
}