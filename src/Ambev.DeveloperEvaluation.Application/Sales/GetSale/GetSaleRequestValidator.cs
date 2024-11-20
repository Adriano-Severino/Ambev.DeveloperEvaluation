using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Validator for GetSaleRequest that defines validation rules for retrieving a sale.
/// </summary>
public class GetSaleRequestValidator : AbstractValidator<GetSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the GetSaleRequestValidator with defined validation rules.
    /// </summary>
    public GetSaleRequestValidator()
    {
        RuleFor(sale => sale.Id).NotEmpty().WithMessage("Sale ID cannot be empty.");
    }
}
