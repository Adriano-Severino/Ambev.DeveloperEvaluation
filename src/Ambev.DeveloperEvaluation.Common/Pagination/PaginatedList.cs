using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.Common.Pagination
{
    /// <summary>
    /// Represents a paginated list of items.
    /// </summary>
    /// <typeparam name="T">The type of items in the list.</typeparam>
    public class PaginatedList<T> : List<T>
    {
        /// <summary>
        /// Gets the current page number.
        /// </summary>
        public int CurrentPage { get; private set; }

        /// <summary>
        /// Gets the total number of pages.
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Gets the number of items per page.
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// Gets the total number of items.
        /// </summary>
        public int TotalCount { get; private set; }

        /// <summary>
        /// Gets a value indicating whether there is a previous page.
        /// </summary>
        public bool HasPrevious => CurrentPage > 1;

        /// <summary>
        /// Gets a value indicating whether there is a next page.
        /// </summary>
        public bool HasNext => CurrentPage < TotalPages;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatedList{T}"/> class.
        /// </summary>
        /// <param name="items">The items to include in the list.</param>
        /// <param name="count">The total number of items.</param>
        /// <param name="pageNumber">The current page number.</param>
        /// <param name="pageSize">The number of items per page.</param>
        public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            AddRange(items);
        }

        /// <summary>
        /// Creates a new instance of <see cref="PaginatedList{T}"/> asynchronously.
        /// </summary>
        /// <param name="source">The source IQueryable to paginate.</param>
        /// <param name="pageNumber">The page number to retrieve.</param>
        /// <param name="pageSize">The number of items per page.</param>
        /// <returns>A task representing the asynchronous operation. The task result contains the paginated list.</returns>
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
