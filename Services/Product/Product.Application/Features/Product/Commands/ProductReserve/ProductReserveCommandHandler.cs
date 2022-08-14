using AutoMapper;
using MediatR;
using ProductService.Application.Contracts.Persistence;
using ProductService.Application.Features.Product.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Application.Features.Orders.Commands.ProductReserve
{
    public class ProductReserveCommandHandler : IRequestHandler<ProductReserveCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductReserveCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> Handle(ProductReserveCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var command = _mapper.Map<ProductReserveCommand>(request);
                var production = await _productRepository.GetOrdersByName(command.ProductName);
                production.Amount = production.Amount - command.Unit;  
                await _productRepository.UpdateAsync(production);
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }


    }
}
