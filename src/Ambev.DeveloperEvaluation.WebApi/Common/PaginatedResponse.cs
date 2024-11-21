namespace Ambev.DeveloperEvaluation.WebApi.Common
{
    /// <summary>
    /// Represents a paginated response with data.
    /// </summary>
    /// <typeparam name="T">The type of items included in the response.</typeparam>
    public class PaginatedResponse<T> : ApiResponseWithData<IEnumerable<T>>
    {
        /// <summary>
        /// Gets or sets the current page number.
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets the total number of pages.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Gets or sets the total number of items.
        /// </summary>
        public int TotalCount { get; set; }
    }
}
