using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Product.Application.Exceptions;
using ProductService.Application.Contracts.Persistence;
using ProductService.Application.Features.Orders.Commands.UpdateOrder;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ILogger<UpdateProductCommandHandler> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(request.Id);
            if (productToUpdate == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }
            
            _mapper.Map(request, productToUpdate, typeof(UpdateProductCommand), typeof(ProductService.Domain.Entities.Product));

            await _productRepository.UpdateAsync(productToUpdate);

            _logger.LogInformation($"Product {productToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}
