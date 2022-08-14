using AutoMapper;
using CustomerService.Application.Contracts.Persistence;
using CustomerService.Application.Features.Orders.Queries.GetOrdersList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerService.Application.Features.Product.Queries.GetOrdersList
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, List<CustomersVm>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandler(ICustomerRepository orderRepository, IMapper mapper)
        {
            _customerRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<CustomersVm>> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            var productList = await _customerRepository.GetOrdersByUserName(request.UserName);
            return _mapper.Map<List<CustomersVm>>(productList);
        }
    }
}
