using FluentValidation;

namespace Ambev.DeveloperEvaluation.Common.Validation
{
    /// <summary>
    /// Provides validation methods for various entities.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Validates an instance of a specified type asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the instance to validate.</typeparam>
        /// <param name="instance">The instance to validate.</param>
        /// <returns>A collection of validation error details if validation fails; otherwise, an empty collection.</returns>
        public static async Task<IEnumerable<ValidationErrorDetail>> ValidateAsync<T>(T instance)
        {
            Type validatorType = typeof(IValidator<>).MakeGenericType(typeof(T));

            if (Activator.CreateInstance(validatorType) is not IValidator validator)
            {
                throw new InvalidOperationException($"No validator found for: {typeof(T).Name}");
            }

            var result = await validator.ValidateAsync(new ValidationContext<T>(instance));

            if (!result.IsValid)
            {
                return result.Errors.Select(o => (ValidationErrorDetail)o);
            }

            return [];
        }
    }
}
