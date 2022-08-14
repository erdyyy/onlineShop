using AutoMapper;
using MediatR;
using Product.Application.Contracts.Persistence;
using ProductService.Application.Contracts.Persistence;
using ProductService.Application.Features.Orders.Queries;
using ProductService.Application.Features.Orders.Queries.GetOrdersList;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Product.Application.Features.Product.Queries.GetOrdersList
{
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, List<ProductsVm>>
    {
        private readonly IProductRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetProductsListQueryHandler(IProductRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<ProductsVm>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var productList = await _orderRepository.GetOrdersByName(request.Name);
            return _mapper.Map<List<ProductsVm>>(productList);
        }
    }
}
