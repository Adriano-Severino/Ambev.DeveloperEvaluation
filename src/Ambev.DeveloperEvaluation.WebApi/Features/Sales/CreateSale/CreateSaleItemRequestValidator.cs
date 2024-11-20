using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleItemRequestValidator : AbstractValidator<CreateSaleItemRequest>
    {
        public CreateSaleItemRequestValidator()
        {
            RuleFor(item => item.ProductName).NotEmpty().WithMessage("Product name cannot be empty.");
            RuleFor(item => item.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
            RuleFor(item => item.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than 0.");
        }
    }
}
