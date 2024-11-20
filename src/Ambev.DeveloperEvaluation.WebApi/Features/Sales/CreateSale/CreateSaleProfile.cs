using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    /// <summary>
    /// Profile for mapping between Application and API CreateSale responses.
    /// </summary>
    public class CreateSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateSale feature.
        /// </summary>
        public CreateSaleProfile()
        {
            // Mapeamento para CreateSaleRequest para CreateSaleCommand
            CreateMap<CreateSaleRequest, CreateSaleCommand>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<CreateSaleItemRequest, CreateSaleItemCommand>();

           

            // Mapeamento para CreateSaleResult para CreateSaleResponse
            CreateMap<CreateSaleResult, CreateSaleResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<CreateSaleItemResult, CreateSaleItemResponse>();

            // Mapeamento inverso (se necessário)
            CreateMap<CreateSaleResponse, CreateSaleResult>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}
