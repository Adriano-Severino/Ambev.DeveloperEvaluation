using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetAllSales;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetAllSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mapping
{
    /// <summary>
    /// Profile for AutoMapper configuration for sales related mappings.
    /// </summary>
    public class GetAllSalesProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllSalesProfile"/> class.
        /// </summary>
        public GetAllSalesProfile()
        {
            CreateMap<Sale, GetSaleResult>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<SaleItem, GetSaleItemResult>();

            CreateMap<Sale, GetAllSalesResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<SaleItem, GetSaleItemResponse>();

            CreateMap<Sale, GetAllSalesResult>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<SaleItem, GetAllSaleItemResult>();

            CreateMap<GetAllSalesResult, GetSaleResponse>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<GetAllSaleItemResult, GetSaleItemResponse>();
        }
    }
}
