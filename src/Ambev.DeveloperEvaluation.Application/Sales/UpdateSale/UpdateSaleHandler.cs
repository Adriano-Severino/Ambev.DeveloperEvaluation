using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale
{
    /// <summary>
    /// Handler for processing UpdateSaleCommand requests.
    /// </summary>
    public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSaleHandler"/> class.
        /// </summary>
        /// <param name="saleRepository">The sale repository instance.</param>
        /// <param name="mapper">The AutoMapper instance.</param>
        public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the UpdateSaleCommand request.
        /// </summary>
        /// <param name="command">The update sale command.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The result of the update operation.</returns>
        /// <exception cref="ValidationException">Thrown when the validation fails.</exception>
        /// <exception cref="KeyNotFoundException">Thrown when the sale is not found.</exception>
        public async Task<UpdateSaleResult> Handle(UpdateSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateSaleCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = await _saleRepository.GetByIdAsync(command.Id, cancellationToken);
            if (sale == null)
                throw new KeyNotFoundException("Sale not found.");

            sale.SaleDate = command.SaleDate;
            sale.Customer = command.Customer;
            sale.Branch = command.Branch;

            sale.Items.Clear();
            foreach (var itemCommand in command.Items)
            {
                var saleItem = new SaleItem
                {
                    ProductName = itemCommand.ProductName,
                    Quantity = itemCommand.Quantity,
                    UnitPrice = itemCommand.UnitPrice
                };
                sale.AddItem(saleItem);
            }

            sale.ApplyDiscounts();
            sale.CalculateTotal();

            await _saleRepository.UpdateAsync(sale, cancellationToken);

            var result = _mapper.Map<UpdateSaleResult>(sale);
            return result;
        }
    }
}
