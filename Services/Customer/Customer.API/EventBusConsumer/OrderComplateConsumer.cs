using AutoMapper;
using CustomerService.Application.Features.AddCustomer.Commands;
using CustomerService.Application.Features.Customer.Commands.UpdateCustomer;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CustomerService.API.EventBusConsumer
{
    public class OrderComplateConsumer : IConsumer<OrderComplateEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
  
        public OrderComplateConsumer(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Consume(ConsumeContext<OrderComplateEvent> context)
        {
            var command = _mapper.Map<AddCustomerCommand>(context.Message);            
            var result = await _mediator.Send(command);

        }

        public async Task Consume(ConsumeContext<ProductReserveEvent> context)
        {
            var command = _mapper.Map<UpdateCustomerCommand>(context.Message);
            var result = await _mediator.Send(command);

        }
    }
}
