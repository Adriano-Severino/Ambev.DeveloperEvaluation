using Ambev.DeveloperEvaluation.Domain.Dto;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Users.ListAllUsers
{
    /// <summary>
    /// Profile for mapping between User entity and UserDto
    /// </summary>
    public class ListAllUsersProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for ListAllUsers operation
        /// </summary>
        public ListAllUsersProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
