using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    public class UpdateSaleItemRequestValidator : AbstractValidator<UpdateSaleItemRequest>
    {
        public UpdateSaleItemRequestValidator()
        {
            RuleFor(item => item.ProductName).NotEmpty().WithMessage("Product name cannot be empty.");
            RuleFor(item => item.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
            RuleFor(item => item.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than 0.");
        }
    }
}
