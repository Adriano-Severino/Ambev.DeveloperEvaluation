using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Validator for UpdateSaleItemCommand that defines validation rules for updating a sale item.
    /// </summary>
    public class UpdateSaleItemCommandValidator : AbstractValidator<UpdateSaleItemCommand>
    {
        /// <summary>
        /// Initializes a new instance of the UpdateSaleItemCommandValidator with defined validation rules.
        /// </summary>
        public UpdateSaleItemCommandValidator()
        {
            RuleFor(item => item.ProductName).NotEmpty().WithMessage("Product name cannot be empty.");
            RuleFor(item => item.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
            RuleFor(item => item.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than 0.");
        }
    }
}
