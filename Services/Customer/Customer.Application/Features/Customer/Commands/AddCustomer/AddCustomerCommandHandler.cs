using AutoMapper;
using CustomerService.Application.Contracts.Persistence;
using CustomerService.Application.Features.AddCustomer.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Application.Features.Customer.Commands.AddCustomer
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public AddCustomerCommandHandler(ICustomerRepository productRepository, IMapper mapper)
        {
            _customerRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = _mapper.Map<Domain.Entities.Customer>(request);
                await _customerRepository.AddAsync(customer);
                return true;

            }
            catch (Exception ex)
            {

                return false;
            }
        }


    }
}
