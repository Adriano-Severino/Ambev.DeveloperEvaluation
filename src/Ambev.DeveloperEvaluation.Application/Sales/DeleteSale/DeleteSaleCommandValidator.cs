using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    /// <summary>
    /// Validator for DeleteSaleCommand that defines validation rules for deleting a sale.
    /// </summary>
    public class DeleteSaleCommandValidator : AbstractValidator<DeleteSaleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the DeleteSaleCommandValidator with defined validation rules.
        /// </summary>
        public DeleteSaleCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty().WithMessage("Sale ID cannot be empty.");
        }
    }
}
