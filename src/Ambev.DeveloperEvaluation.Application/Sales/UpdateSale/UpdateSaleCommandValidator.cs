using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Validator for UpdateSaleCommand that defines validation rules for sale updating.
    /// </summary>
    public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the UpdateSaleCommandValidator with defined validation rules.
        /// </summary>
        public UpdateSaleCommandValidator()
        {
            RuleFor(sale => sale.SaleDate).NotEmpty().WithMessage("Sale date cannot be empty.");
            RuleFor(sale => sale.Customer).NotEmpty().MinimumLength(3).MaximumLength(50).WithMessage("Customer must be between 3 and 50 characters.");
            RuleFor(sale => sale.Branch).NotEmpty().MinimumLength(3).MaximumLength(50).WithMessage("Branch must be between 3 and 50 characters.");
            RuleForEach(sale => sale.Items).SetValidator(new UpdateSaleItemCommandValidator());
        }
    }
}
