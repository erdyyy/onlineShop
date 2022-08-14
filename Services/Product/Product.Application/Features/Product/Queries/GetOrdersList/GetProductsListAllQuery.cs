using MediatR;
using System;
using System.Collections.Generic;

namespace ProductService.Application.Features.Orders.Queries
{
    public class GetProductsListAllQuery : IRequest<List<ProductsVm>>
    {

        public GetProductsListAllQuery()
        {
        
        }
    }
}
