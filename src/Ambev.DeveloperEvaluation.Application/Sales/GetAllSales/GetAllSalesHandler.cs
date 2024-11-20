using MediatR;
using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetAllSales
{
    /// <summary>
    /// Handler for processing GetAllSalesCommand requests
    /// </summary>
    public class GetAllSalesHandler : IRequestHandler<GetAllSalesCommand, List<GetAllSalesResult>>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetAllSalesHandler
        /// </summary>
        /// <param name="saleRepository">The sale repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public GetAllSalesHandler(ISaleRepository saleRepository, IMapper mapper)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetAllSalesCommand request
        /// </summary>
        /// <param name="command">The GetAllSales command</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>A list of sales</returns>
        public async Task<List<GetAllSalesResult>> Handle(GetAllSalesCommand command, CancellationToken cancellationToken)
        {
            var sales = await _saleRepository.GetAllAsync(cancellationToken);
            return _mapper.Map<List<GetAllSalesResult>>(sales);
        }
    }
}
