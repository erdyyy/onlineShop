using AutoMapper;
using CustomerService.Application.Features.AddCustomer.Commands;
using CustomerService.Application.Features.Customer.Commands.DeleteCustomer;
using CustomerService.Application.Features.Customer.Commands.UpdateCustomer;
using CustomerService.Application.Features.Orders.Queries.GetOrdersList;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Ordering.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;
        public CustomerController(IMediator mediator, IPublishEndpoint publishEndpoint, IMapper mapper)
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



        [HttpGet("{userName}", Name = "GetOrder")]
        [ProducesResponseType(typeof(IEnumerable<CustomersVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CustomersVm>>> GetOrdersByUserName(string userName)
        {
            var query = new GetCustomersListQuery(userName);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        // testing purpose
        [HttpPost(Name = "ProductReserve")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> ProductReserve([FromBody] AddCustomerCommand productReserve)
        {
            var eventMessage = _mapper.Map<OrderComplateEvent>(productReserve);
            await _publishEndpoint.Publish<OrderComplateEvent>(eventMessage);
            var result = await _mediator.Send(productReserve);
            
            return Ok(result);
        }

        [HttpPut(Name = "UpdateOrder")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateOrder([FromBody] UpdateCustomerCommand command)
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
            var command = new DeleteCustomerCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
