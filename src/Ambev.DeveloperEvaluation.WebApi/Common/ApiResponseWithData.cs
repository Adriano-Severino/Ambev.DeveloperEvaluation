namespace Ambev.DeveloperEvaluation.WebApi.Common
{
    /// <summary>
    /// Represents a standard API response with data.
    /// </summary>
    /// <typeparam name="T">The type of the data included in the response.</typeparam>
    public class ApiResponseWithData<T> : ApiResponse
    {
        /// <summary>
        /// Gets or sets the data included in the response.
        /// </summary>
        public T? Data { get; set; }
    }
}
