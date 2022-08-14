using MediatR;
using System;
using System.Collections.Generic;

namespace ProductService.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetProductsListQuery : IRequest<List<ProductsVm>>
    {
        public string Name { get; set; }

        public GetProductsListQuery(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
