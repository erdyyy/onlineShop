using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Product.Application.Contracts.Persistence;
using Product.Application.Features.Product.Commands;

using ProductService.Application.Contracts.Persistence;
using ProductService.Application.Features.Product.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Application.Features.Product.Commands.ProductReserve
{
    public class ProductReserveCommandHandler : IRequestHandler<ProductReserveCommand, int>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductReserveCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<long> Handle(ProductReserveCommand request, CancellationToken cancellationToken)
        {
            var orderEntity = _mapper.Map<ProductService.Domain.Entities.Product>(request);
            var newOrder = await _productRepository.AddAsync(orderEntity);



            return newOrder.Id;
        }


    }
}
