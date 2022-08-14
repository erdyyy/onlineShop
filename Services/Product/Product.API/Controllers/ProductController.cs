using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Features.Orders.Commands.DeleteOrder;
using ProductService.Application.Features.Orders.Commands.UpdateOrder;
using ProductService.Application.Features.Orders.Queries;
using ProductService.Application.Features.Orders.Queries.GetOrdersList;
using ProductService.Application.Features.Product.Commands;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ProductService.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;
        public ProductController(IMediator mediator, IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("test")]
        public bool test()
        {

            return true;
        }

        [HttpGet(Name = "GetProducts")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IEnumerable<ProductsVm>> GetProducts()
        {
            var query = new GetProductsListAllQuery();
            var products = await _mediator.Send(query);
            return products;
        }

        [HttpGet("{name}", Name = "GetOrdersByUserName")]
        [ProducesResponseType(typeof(IEnumerable<ProductsVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ProductsVm>>> GetProductsByName(string name)
        {
            var query = new GetProductsListQuery(name);
            var products = await _mediator.Send(query);
            return Ok(products);
        }

        // testing purpose
        [HttpPost(Name = "ProductReserve")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> ProductReserve([FromBody] ProductReserveCommand productReserve)
        {

            await _publishEndpoint.Publish(_mapper.Map<ProductReserveEvent>(productReserve));
            return Ok(productReserve);
        }

        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var command = new DeleteProductCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
