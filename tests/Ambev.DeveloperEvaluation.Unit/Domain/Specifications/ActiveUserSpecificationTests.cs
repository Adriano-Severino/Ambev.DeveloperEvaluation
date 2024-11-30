using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Specifications;
using Ambev.DeveloperEvaluation.Unit.Domain.Specifications.TestData;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Specifications
{
    /// <summary>
    /// Contains unit tests for the <see cref="ActiveUserSpecification"/> class.
    /// </summary>
    public class ActiveUserSpecificationTests
    {
        /// <summary>
        /// Verifies that the <see cref="ActiveUserSpecification"/> correctly validates user status.
        /// </summary>
        /// <param name="status">The user status to be validated.</param>
        /// <param name="expectedResult">The expected result of the validation.</param>
        [Theory]
        [InlineData(UserStatus.Active, true)]
        [InlineData(UserStatus.Inactive, false)]
        [InlineData(UserStatus.Suspended, false)]
        public void IsSatisfiedBy_ShouldValidateUserStatus(UserStatus status, bool expectedResult)
        {
            // Arrange
            var user = ActiveUserSpecificationTestData.GenerateUser(status);
            var specification = new ActiveUserSpecification();

            // Act
            var result = specification.IsSatisfiedBy(user);

            // Assert
            result.Should().Be(expectedResult);
        }
    }
}
