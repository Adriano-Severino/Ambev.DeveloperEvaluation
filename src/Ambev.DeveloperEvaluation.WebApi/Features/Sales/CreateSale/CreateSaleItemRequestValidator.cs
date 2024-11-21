using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Validator for CreateSaleItemRequest that defines validation rules for creating a sale item.
    /// </summary>
    public class CreateSaleItemRequestValidator : AbstractValidator<CreateSaleItemRequest>
    {
        /// <summary>
        /// Initializes a new instance of the CreateSaleItemRequestValidator with defined validation rules.
        /// </summary>
        public CreateSaleItemRequestValidator()
        {
            RuleFor(item => item.ProductName).NotEmpty().WithMessage("Product name cannot be empty.");
            RuleFor(item => item.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
            RuleFor(item => item.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than 0.");
        }
    }
}
