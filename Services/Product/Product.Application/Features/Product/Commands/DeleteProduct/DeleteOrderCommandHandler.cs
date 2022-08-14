using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Exceptions;
using Product.Application.Exceptions;
using ProductService.Application.Contracts.Persistence;
using ProductService.Application.Features.Orders.Commands.DeleteOrder;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteOrderCommandHandler> _logger;

        public DeleteOrderCommandHandler(IProductRepository orderRepository, IMapper mapper, ILogger<DeleteOrderCommandHandler> logger)
        {
            _productRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _productRepository.GetByIdAsync(request.Id);
            if (productToDelete == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }            

            await _productRepository.DeleteAsync(productToDelete);

            _logger.LogInformation($"Product {productToDelete.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}
