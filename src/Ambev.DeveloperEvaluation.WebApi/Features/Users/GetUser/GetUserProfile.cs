using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.GetUser;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users
{
    /// <summary>
    /// Profile for mapping GetUser feature requests to commands
    /// </summary>
    public class GetUserProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetUser feature
        /// </summary>
        public GetUserProfile()
        {
            CreateMap<User, GetUserResult>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
            CreateMap<GetUserResult, GetUserResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));
            CreateMap<Guid, GetUserCommand>()
                .ConstructUsing(id => new GetUserCommand(id));
        }
    }
}
