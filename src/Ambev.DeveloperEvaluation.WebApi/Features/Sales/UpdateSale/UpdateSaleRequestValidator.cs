using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    /// <summary>
    /// Validator for UpdateSaleRequest that defines validation rules for sale updating.
    /// </summary>
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        /// <summary>
        /// Initializes a new instance of the UpdateSaleRequestValidator with defined validation rules.
        /// </summary>
        public UpdateSaleRequestValidator()
        {
            RuleFor(sale => sale.SaleDate).NotEmpty().WithMessage("Sale date cannot be empty.");
            RuleFor(sale => sale.Customer).NotEmpty().MinimumLength(3).MaximumLength(50).WithMessage("Customer must be between 3 and 50 characters.");
            RuleFor(sale => sale.Branch).NotEmpty().MinimumLength(3).MaximumLength(50).WithMessage("Branch must be between 3 and 50 characters.");
            RuleForEach(sale => sale.Items).SetValidator(new UpdateSaleItemRequestValidator());
        }
    }
}
