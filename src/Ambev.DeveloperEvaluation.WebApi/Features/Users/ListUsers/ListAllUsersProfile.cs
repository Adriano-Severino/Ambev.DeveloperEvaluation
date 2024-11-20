using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Users.ListAllUsers;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.ListAllUsers;
using Ambev.DeveloperEvaluation.Domain.Dto;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.ListAllUsers
{
    /// <summary>
    /// Profile for mapping between Application and API ListAllUsers responses
    /// </summary>
    public class ListAllUsersProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for ListAllUsers feature
        /// </summary>
        public ListAllUsersProfile()
        {
            CreateMap<ListAllUsersRequest, ListAllUsersCommand>();
            CreateMap<ListAllUsersResult, ListAllUsersResponse>();
            CreateMap<UserDto, UserDto>();
        }
    }
}
