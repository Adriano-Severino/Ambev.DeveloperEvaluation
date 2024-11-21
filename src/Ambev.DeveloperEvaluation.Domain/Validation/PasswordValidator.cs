using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    /// <summary>
    /// Validator for validating passwords.
    /// </summary>
    public class PasswordValidator : AbstractValidator<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PasswordValidator"/> class.
        /// </summary>
        public PasswordValidator()
        {
            RuleFor(password => password)
                .NotEmpty()
                .MinimumLength(8)
                .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Password must contain at least one number.")
                .Matches(@"[\!\?\*\.\@\#\$\%\^\&\+\=]+").WithMessage("Password must contain at least one special character.");
        }
    }
}
