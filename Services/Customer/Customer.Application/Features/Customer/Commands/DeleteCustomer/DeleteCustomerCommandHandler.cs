using AutoMapper;
using CustomerService.Application.Contracts.Persistence;
using CustomerService.Application.Exceptions;
using CustomerService.Application.Features.Customer.Commands.DeleteCustomer;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCustomerCommandHandler> _logger;

        public DeleteCustomerCommandHandler(ICustomerRepository orderRepository, IMapper mapper, ILogger<DeleteCustomerCommandHandler> logger)
        {
            _customerRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var productToDelete = await _customerRepository.GetByIdAsync(request.Id);
            if (productToDelete == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }            

            await _customerRepository.DeleteAsync(productToDelete);

            _logger.LogInformation($"Customer {productToDelete.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}
