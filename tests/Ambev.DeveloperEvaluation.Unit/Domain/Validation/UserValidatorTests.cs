using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation
{
    /// <summary>
    /// Contains unit tests for the <see cref="UserValidator"/> class.
    /// Tests cover validation of all user properties including username, email,
    /// password, phone, status, and role requirements.
    /// </summary>
    public class UserValidatorTests
    {
        private readonly UserValidator _validator;

        public UserValidatorTests()
        {
            _validator = new UserValidator();
        }

        /// <summary>
        /// Tests that a valid user passes all validation rules.
        /// </summary>
        [Fact(DisplayName = "Valid user should pass all validation rules")]
        public void Given_ValidUser_When_Validated_Then_ShouldNotHaveErrors()
        {
            var user = UserTestData.GenerateValidUser();
            var result = _validator.TestValidate(user);
            result.ShouldNotHaveAnyValidationErrors();
        }

        /// <summary>
        /// Tests that invalid username formats fail validation.
        /// </summary>
        [Theory(DisplayName = "Invalid username formats should fail validation")]
        [InlineData("")] // Empty
        [InlineData("ab")] // Less than 3 characters
        public void Given_InvalidUsername_When_Validated_Then_ShouldHaveError(string username)
        {
            var user = UserTestData.GenerateValidUser();
            var invalidUser = new User(username, user.Email, user.Phone, user.Password, user.Role);
            var result = _validator.TestValidate(invalidUser);
            result.ShouldHaveValidationErrorFor(x => x.Username);
        }

        /// <summary>
        /// Tests that usernames longer than the maximum allowed length fail validation.
        /// </summary>
        [Fact(DisplayName = "Username longer than maximum length should fail validation")]
        public void Given_UsernameLongerThanMaximum_When_Validated_Then_ShouldHaveError()
        {
            var user = UserTestData.GenerateValidUser();
            var invalidUser = new User(UserTestData.GenerateLongUsername(), user.Email, user.Phone, user.Password, user.Role);
            var result = _validator.TestValidate(invalidUser);
            result.ShouldHaveValidationErrorFor(x => x.Username);
        }

        /// <summary>
        /// Tests that invalid email formats fail validation.
        /// </summary>
        [Fact(DisplayName = "Invalid email formats should fail validation")]
        public void Given_InvalidEmail_When_Validated_Then_ShouldHaveError()
        {
            var invalidEmail = "invalid-email";
            var emailValidator = new EmailValidator();
            var emailResult = emailValidator.TestValidate(invalidEmail);

            emailResult.ShouldHaveValidationErrorFor(e => e)
                .WithErrorMessage("The provided email address is not valid.");
        }

        /// <summary>
        /// Tests that invalid password formats fail validation.
        /// </summary>
        [Theory(DisplayName = "Invalid password formats should fail validation")]
        [InlineData("", "Password is required.")]
        [InlineData("short", "Password must be at least 8 characters long.")]
        [InlineData("lowercase123", "Password must contain at least one uppercase letter.")]
        [InlineData("LOWERCASE123", "Password must contain at least one lowercase letter.")]
        [InlineData("Lowercase@", "Password must contain at least one number.")]
        [InlineData("Lowercase123", "Password must contain at least one special character.")]
        public void Given_InvalidPassword_When_Validated_Then_ShouldHaveError(string invalidPassword, string expectedErrorMessage)
        {
            var passwordValidator = new PasswordValidator();
            var passwordResult = passwordValidator.TestValidate(invalidPassword);

            passwordResult.ShouldHaveValidationErrorFor(p => p)
                .WithErrorMessage(expectedErrorMessage);
        }


        /// <summary>
        /// Tests that invalid phone number formats fail validation.
        /// </summary>
        [Fact(DisplayName = "Invalid phone formats should fail validation")]
        public void Given_InvalidPhone_When_Validated_Then_ShouldHaveError()
        {
            var invalidPhoneNumber = UserTestData.GenerateInvalidPhone();
            var phoneNumberValidator = new PhoneValidator();

            var phoneNumberResult = phoneNumberValidator.TestValidate(invalidPhoneNumber);
            phoneNumberResult.ShouldHaveValidationErrorFor(p => p)
                .WithErrorMessage("The phone format is not valid.");
        }

        /// <summary>
        /// Tests that unknown user statuses fail validation.
        /// </summary>
        [Fact(DisplayName = "Unknown status should fail validation")]
        public void Given_UnknownStatus_When_Validated_Then_ShouldHaveError()
        {
            var user = UserTestData.GenerateValidUser();
            user.Suspend();
            user.SetStatus(UserStatus.Unknown);
            var result = _validator.TestValidate(user);
            result.ShouldHaveValidationErrorFor(x => x.Status);
        }

        /// <summary>
        /// Tests that a role of 'None' fails validation.
        /// </summary>
        [Fact(DisplayName = "None role should fail validation")]
        public void Given_NoneRole_When_Validated_Then_ShouldHaveError()
        {
            var user = UserTestData.GenerateValidUser();
            user.SetRole(UserRole.None);
            var result = _validator.TestValidate(user);
            result.ShouldHaveValidationErrorFor(x => x.Role);
        }
    }
}
