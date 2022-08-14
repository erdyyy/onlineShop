using AutoMapper;
using MediatR;
using ProductService.Application.Contracts.Persistence;
using ProductService.Application.Features.Orders.Queries;
using ProductService.Application.Features.Orders.Queries.GetOrdersList;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Application.Features.Product.Queries
{
    public class GetProductsListAllQueryHandler : IRequestHandler<GetProductsListAllQuery, List<ProductsVm>>
    {
        private readonly IProductRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetProductsListAllQueryHandler(IProductRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<ProductsVm>> Handle(GetProductsListAllQuery request, CancellationToken cancellationToken)
        {
            var productList = await _orderRepository.GetAllAsync();
            return _mapper.Map<List<ProductsVm>>(productList);
        }
    }
}
