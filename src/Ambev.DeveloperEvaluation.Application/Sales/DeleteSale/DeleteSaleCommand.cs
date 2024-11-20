using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;
using System;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    /// <summary>
    /// Command for deleting a sale.
    /// </summary>
    public class DeleteSaleCommand : IRequest<Unit>
    {
        /// <summary>
        /// Gets or sets the unique identifier of the sale to delete.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Initializes a new instance of the DeleteSaleCommand.
        /// </summary>
        /// <param name="id">The unique identifier of the sale to delete.</param>
        public DeleteSaleCommand(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Validates the DeleteSaleCommand.
        /// </summary>
        /// <returns>The validation result details.</returns>
        public ValidationResultDetail Validate()
        {
            var validator = new DeleteSaleCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
