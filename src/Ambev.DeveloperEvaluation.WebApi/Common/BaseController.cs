using Ambev.DeveloperEvaluation.Common.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ambev.DeveloperEvaluation.WebApi.Common
{
    /// <summary>
    /// Base controller providing common functionalities for API controllers.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Gets the current user's ID.
        /// </summary>
        /// <returns>The current user's ID.</returns>
        /// <exception cref="NullReferenceException">Thrown when the user ID claim is not found.</exception>
        protected int GetCurrentUserId() =>
            int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NullReferenceException());

        /// <summary>
        /// Gets the current user's email.
        /// </summary>
        /// <returns>The current user's email.</returns>
        /// <exception cref="NullReferenceException">Thrown when the email claim is not found.</exception>
        protected string GetCurrentUserEmail() =>
            User.FindFirst(ClaimTypes.Email)?.Value ?? throw new NullReferenceException();

        /// <summary>
        /// Creates an Ok response with data.
        /// </summary>
        /// <typeparam name="T">The type of the data.</typeparam>
        /// <param name="data">The data to include in the response.</param>
        /// <returns>An Ok result with the specified data.</returns>
        protected IActionResult Ok<T>(T data) =>
            base.Ok(new ApiResponseWithData<T> { Data = data, Success = true });

        /// <summary>
        /// Creates a Created response with data.
        /// </summary>
        /// <typeparam name="T">The type of the data.</typeparam>
        /// <param name="routeName">The name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="data">The data to include in the response.</param>
        /// <returns>A Created result with the specified data.</returns>
        protected IActionResult Created<T>(string routeName, object routeValues, T data) =>
            base.CreatedAtRoute(routeName, routeValues, new ApiResponseWithData<T> { Data = data, Success = true });

        /// <summary>
        /// Creates a BadRequest response with a message.
        /// </summary>
        /// <param name="message">The message to include in the response.</param>
        /// <returns>A BadRequest result with the specified message.</returns>
        protected IActionResult BadRequest(string message) =>
            base.BadRequest(new ApiResponse { Message = message, Success = false });

        /// <summary>
        /// Creates a NotFound response with a message.
        /// </summary>
        /// <param name="message">The message to include in the response.</param>
        /// <returns>A NotFound result with the specified message.</returns>
        protected IActionResult NotFound(string message = "Resource not found") =>
            base.NotFound(new ApiResponse { Message = message, Success = false });

        /// <summary>
        /// Creates an Ok response with paginated data.
        /// </summary>
        /// <typeparam name="T">The type of the data.</typeparam>
        /// <param name="pagedList">The paginated list of data.</param>
        /// <returns>An Ok result with the paginated data.</returns>
        protected IActionResult OkPaginated<T>(PaginatedList<T> pagedList) =>
            Ok(new PaginatedResponse<T>
            {
                Data = pagedList,
                CurrentPage = pagedList.CurrentPage,
                TotalPages = pagedList.TotalPages,
                TotalCount = pagedList.TotalCount,
                Success = true
            });
    }
}
