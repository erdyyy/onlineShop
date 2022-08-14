using MediatR;
using System;
using System.Collections.Generic;

namespace CustomerService.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetCustomersListQuery : IRequest<List<CustomersVm>>
    {
        public string UserName { get; set; }

        public GetCustomersListQuery(string name)
        {
            name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
