﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for sale creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.SaleDate).NotEmpty().WithMessage("Sale date cannot be empty.");
        RuleFor(sale => sale.Customer).NotEmpty().MinimumLength(3).MaximumLength(50).WithMessage("Customer must be between 3 and 50 characters.");
        RuleFor(sale => sale.Branch).NotEmpty().MinimumLength(3).MaximumLength(50).WithMessage("Branch must be between 3 and 50 characters.");
        RuleForEach(sale => sale.Items).SetValidator(new CreateSaleItemRequestValidator());
    }
}

public class CreateSaleItemRequestValidator : AbstractValidator<CreateSaleItemRequest>
{
    public CreateSaleItemRequestValidator()
    {
        RuleFor(item => item.ProductName).NotEmpty().WithMessage("Product name cannot be empty.");
        RuleFor(item => item.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        RuleFor(item => item.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than 0.");
    }
}