using Xunit;
using FluentValidation.TestHelper;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.CreateSale
{
    /// <summary>
    /// Contains unit tests for the CreateSaleCommandValidator class.
    /// Tests cover validation rules for sale creation command.
    /// </summary>
    public class CreateSaleCommandValidatorTests
    {
        private readonly CreateSaleCommandValidator _validator;

        public CreateSaleCommandValidatorTests()
        {
            _validator = new CreateSaleCommandValidator();
        }

        [Fact(DisplayName = "Should have validation error when SaleDate is empty")]
        public void Should_HaveValidationError_When_SaleDateIsEmpty()
        {
            var command = new CreateSaleCommand { SaleDate = default };

            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(c => c.SaleDate)
                .WithErrorMessage("Sale date cannot be empty.");
        }
        
        [Fact(DisplayName = "Should have validation error when Customer is more than 50 characters")]
        public void Should_HaveValidationError_When_CustomerIsMoreThan50Characters()
        {
            var command = new CreateSaleCommand { Customer = new string('A', 51) };

            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(c => c.Customer)
                .WithErrorMessage("Customer must be between 3 and 50 characters.");
        }

        [Fact(DisplayName = "Should have validation error when Branch is more than 50 characters")]
        public void Should_HaveValidationError_When_BranchIsMoreThan50Characters()
        {
            var command = new CreateSaleCommand { Branch = new string('A', 51) };

            var result = _validator.TestValidate(command);

            result.ShouldHaveValidationErrorFor(c => c.Branch)
                .WithErrorMessage("Branch must be between 3 and 50 characters.");
        }
    }
}
