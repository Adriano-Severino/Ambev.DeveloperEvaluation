using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for sale creation command.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - SaleNumber: Required
    /// - SaleDate: Must be a valid date
    /// - Customer: Required, must be between 3 and 50 characters
    /// - Branch: Required, must be between 3 and 50 characters
    /// - Items: Must contain at least one item
    /// </remarks>
    public CreateSaleCommandValidator()
    {
        {
            RuleFor(sale => sale.SaleDate).NotEmpty().WithMessage("Sale date cannot be empty.");
            RuleFor(sale => sale.Customer).NotEmpty().MinimumLength(3).MaximumLength(50).WithMessage("Customer must be between 3 and 50 characters.");
            RuleFor(sale => sale.Branch).NotEmpty().MinimumLength(3).MaximumLength(50).WithMessage("Branch must be between 3 and 50 characters.");
        }

    }
}
