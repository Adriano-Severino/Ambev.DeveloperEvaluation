using Xunit;
using Moq;
using AutoMapper;
using MediatR;
using FluentValidation;
using FluentValidation.Results;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Unit.Application.Sales.CreateSale
{
    /// <summary>
    /// Contains unit tests for the CreateSaleHandler class.
    /// Tests cover handling of the CreateSaleCommand and validation scenarios.
    /// </summary>
    public class CreateSaleHandlerTests
    {
        private readonly Mock<ISaleRepository> _mockSaleRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CreateSaleHandler _handler;

        public CreateSaleHandlerTests()
        {
            _mockSaleRepository = new Mock<ISaleRepository>();
            _mockMapper = new Mock<IMapper>();
            _handler = new CreateSaleHandler(_mockSaleRepository.Object, _mockMapper.Object);
        }

        [Fact(DisplayName = "Should throw ValidationException when command is invalid")]
        public async Task Handle_InvalidCommand_ThrowsValidationException()
        {
            // Arrange
            var command = new CreateSaleCommand();
            var validator = new CreateSaleCommandValidator();
            var validationResult = new ValidationResult(new List<ValidationFailure>
            {
                new ValidationFailure("Customer", "Customer must be between 3 and 50 characters.")
            });

            var mockValidator = new Mock<IValidator<CreateSaleCommand>>();
            mockValidator.Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>())).ReturnsAsync(validationResult);

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact(DisplayName = "Should handle valid command and create sale successfully")]
        public async Task Handle_ValidCommand_CreatesSaleSuccessfully()
        {
            // Arrange
            var command = new CreateSaleCommand
            {
                SaleDate = DateTime.Now,
                Customer = "John Doe",
                Branch = "Main Branch",
                Items = new List<CreateSaleItemCommand>
                {
                    new CreateSaleItemCommand { ProductName = "Product A", Quantity = 2, UnitPrice = 100 },
                    new CreateSaleItemCommand { ProductName = "Product B", Quantity = 3, UnitPrice = 200 }
                }
            };

            var sale = new Sale
            {
                SaleDate = command.SaleDate,
                Customer = command.Customer,
                Branch = command.Branch,
                Items = new List<SaleItem>
                {
                    new SaleItem { ProductName = "Product A", Quantity = 2, UnitPrice = 100 },
                    new SaleItem { ProductName = "Product B", Quantity = 3, UnitPrice = 200 }
                }
            };

            _mockSaleRepository.Setup(repo => repo.CreateAsync(It.IsAny<Sale>(), It.IsAny<CancellationToken>())).ReturnsAsync(sale);
            _mockMapper.Setup(mapper => mapper.Map<CreateSaleResult>(It.IsAny<Sale>())).Returns(new CreateSaleResult());

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mockSaleRepository.Verify(repo => repo.CreateAsync(It.IsAny<Sale>(), It.IsAny<CancellationToken>()), Times.Once);
            _mockMapper.Verify(mapper => mapper.Map<CreateSaleResult>(It.IsAny<Sale>()), Times.Once);
            Assert.NotNull(result);
        }
    }
}
