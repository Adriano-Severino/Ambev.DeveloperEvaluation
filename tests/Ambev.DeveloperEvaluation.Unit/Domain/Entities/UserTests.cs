using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the User entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class UserTests
{
    /// <summary>
    /// Tests that when a suspended user is activated, their status changes to Active.
    /// </summary>
    [Fact(DisplayName = "User status should change to Active when activated")]
    public void Given_SuspendedUser_When_Activated_Then_StatusShouldBeActive()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();
        user.Suspend(); // Ensure the user is suspended before activation

        // Act
        user.Activate();

        // Assert
        Assert.Equal(UserStatus.Active, user.Status);
    }

    /// <summary>
    /// Tests that when an active user is suspended, their status changes to Suspended.
    /// </summary>
    [Fact(DisplayName = "User status should change to Suspended when suspended")]
    public void Given_ActiveUser_When_Suspended_Then_StatusShouldBeSuspended()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();

        // Act
        user.Suspend();

        // Assert
        Assert.Equal(UserStatus.Suspended, user.Status);
    }

    /// <summary>
    /// Tests that validation passes when all user properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid user data")]
    public void Given_ValidUserData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var user = UserTestData.GenerateValidUser();

        // Act
        var result = user.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when user properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid user data")]
    public void Given_InvalidUserData_When_Validated_Then_ShouldReturnInvalid()
    {
        // List to store exception error details
        List<ValidationErrorDetail> exceptionErrors = new List<ValidationErrorDetail>();

        // Try to create each VO and capture exceptions for invalid values
        try
        {
            var invalidEmail = new Email(UserTestData.GenerateInvalidEmail());
        }
        catch (DomainException ex)
        {
            exceptionErrors.Add(new ValidationErrorDetail { Detail = ex.Message });
        }

        try
        {
            var invalidPhone = new PhoneNumber(UserTestData.GenerateInvalidPhone());
        }
        catch (DomainException ex)
        {
            exceptionErrors.Add(new ValidationErrorDetail { Detail = ex.Message });
        }

        try
        {
            var invalidPassword = new Password(UserTestData.GenerateInvalidPassword(), new BCryptPasswordHasher());
        }
        catch (DomainException ex)
        {
            exceptionErrors.Add(new ValidationErrorDetail { Detail = ex.Message });
        }

        // Create the user with valid data to avoid exceptions during validation
        var user = new User(
            "", // Invalid: empty
            new Email(UserTestData.GenerateValidEmail()),
            new PhoneNumber(UserTestData.GenerateValidPhone()),
            new Password(UserTestData.GenerateValidPassword(), new BCryptPasswordHasher()), 
            UserRole.None
        );

        // Set status to Unknown
        user.SetStatus(UserStatus.Unknown);

        // Act
        var result = user.Validate();
        var validationErrors = result.Errors.Select(e => new ValidationErrorDetail { Detail = e.Detail, Error = e.Error }).ToList();
        var allErrors = exceptionErrors.Concat(validationErrors).ToList();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(allErrors);
        Assert.Contains(allErrors, e => e.Detail.Contains("Invalid email format"));
        Assert.Contains(allErrors, e => e.Detail.Contains("Invalid phone number format"));
        Assert.Contains(allErrors, e => e.Detail.Contains("Password does not meet complexity requirements"));
        Assert.Contains(allErrors, e => e.Detail.Contains("Username must be at least 3 characters long."));
        Assert.Contains(allErrors, e => e.Detail.Contains("User status cannot be Unknown."));
        Assert.Contains(allErrors, e => e.Detail.Contains("User role cannot be None."));
    }
}
