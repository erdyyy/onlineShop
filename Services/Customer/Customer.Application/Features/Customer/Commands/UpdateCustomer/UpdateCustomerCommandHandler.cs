using AutoMapper;
using CustomerService.Application.Contracts.Persistence;
using CustomerService.Application.Exceptions;
using CustomerService.Application.Features.Customer.Commands.UpdateCustomer;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Customer.Commands.UpdateOrder
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateCustomerCommandHandler> _logger;

        public UpdateCustomerCommandHandler(ICustomerRepository productRepository, IMapper mapper, ILogger<UpdateCustomerCommandHandler> logger)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(request.Id);
            if (productToUpdate == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }
     

            await _productRepository.UpdateAsync(productToUpdate);

            _logger.LogInformation($"Order {productToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}
