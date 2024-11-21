using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings
{
    /// <summary>
    /// Profile for AutoMapper configuration for user creation mappings.
    /// </summary>
    public class CreateUserRequestProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateUserRequestProfile"/> class.
        /// </summary>
        public CreateUserRequestProfile()
        {
            CreateMap<CreateUserRequest, CreateUserCommand>();
        }
    }
}
