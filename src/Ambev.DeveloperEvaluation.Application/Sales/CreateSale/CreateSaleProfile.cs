using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSaleItem
{
    /// <summary>
    /// Profile for AutoMapper configuration for creating sales and sale items.
    /// </summary>
    public class CreateSaleProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSaleProfile"/> class.
        /// </summary>
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleCommand, SaleItem>();
            CreateMap<SaleItem, CreateSaleCommand>();
            CreateMap<Sale, CreateSaleResult>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
            CreateMap<SaleItem, CreateSaleItemResult>();
        }
    }
}
