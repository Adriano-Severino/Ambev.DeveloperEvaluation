using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    /// <summary>
    /// Profile for AutoMapper configuration for sales related mappings.
    /// </summary>
    public class GetSalesProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSalesProfile"/> class.
        /// </summary>
        public GetSalesProfile()
        {
            CreateMap<Sale, GetSaleResult>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<SaleItem, GetSaleItemResult>();

            CreateMap<GetSaleResult, GetSaleResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<GetSaleItemResult, GetSaleItemResponse>();
        }
    }
}
