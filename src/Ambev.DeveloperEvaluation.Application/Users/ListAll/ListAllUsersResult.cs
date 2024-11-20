using Ambev.DeveloperEvaluation.Domain.Dto;

namespace Ambev.DeveloperEvaluation.Application.Users.ListAllUsers
{
    /// <summary>
    /// Represents the response returned after successfully listing all users.
    /// </summary>
    public class ListAllUsersResult
    {
        /// <summary>
        /// Gets or sets the list of users.
        /// </summary>
        public List<UserDto> Users { get; set; } = new List<UserDto>();
    }

   
}
