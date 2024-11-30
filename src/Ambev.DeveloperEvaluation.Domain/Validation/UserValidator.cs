using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    /// <summary>
    /// Validator for validating user entities.
    /// </summary>
    public class UserValidator : AbstractValidator<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserValidator"/> class.
        /// </summary>
        public UserValidator()
        {
            RuleFor(user => user.Email.Value)
                .SetValidator(new EmailValidator());

            RuleFor(user => user.Username)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Username must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("Username cannot be longer than 50 characters.");

            RuleFor(user => user.Password.Value)
                .SetValidator(new PasswordValidator());

            RuleFor(user => user.Phone.Value)
                .SetValidator(new PhoneValidator());

            RuleFor(user => user.Status)
                .NotEqual(UserStatus.Unknown)
                .WithMessage("User status cannot be Unknown.");

            RuleFor(user => user.Role)
                .NotEqual(UserRole.None)
                .WithMessage("User role cannot be None.");
        }
    }
}