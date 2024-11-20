using Ambev.DeveloperEvaluation.Domain.Dto;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListAllUsers
{
    /// <summary>
    /// API response model for ListAllUsers operation
    /// </summary>
    public class ListAllUsersResponse
    {
        /// <summary>
        /// The list of users
        /// </summary>
        public List<UserDto> Users { get; set; } = new List<UserDto>();
    }

   
}
