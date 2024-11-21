using Ambev.DeveloperEvaluation.Common.Validation;

namespace Ambev.DeveloperEvaluation.WebApi.Common
{
    /// <summary>
    /// Represents a standard API response.
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether the request was successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the message associated with the response.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the validation errors associated with the response.
        /// </summary>
        public IEnumerable<ValidationErrorDetail> Errors { get; set; } = new List<ValidationErrorDetail>();
    }
}
