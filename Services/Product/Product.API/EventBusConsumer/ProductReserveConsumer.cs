using AutoMapper;
using EventBus.Messages.Events;
using MassTransit;
using MediatR;
using ProductService.Application.Contracts.Persistence;
using ProductService.Application.Features.Product.Commands;
using System;
using System.Threading.Tasks;

namespace ProductService.API.EventBusConsumer
{
    public class ProductReserveConsumer : IConsumer<OrderComplateEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IProductRepository _repository;

        public ProductReserveConsumer(IMediator mediator, IMapper mapper, IProductRepository repository)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        async Task IConsumer<OrderComplateEvent>.Consume(ConsumeContext<OrderComplateEvent> context)
        {

            await _mediator.Send(_mapper.Map<ProductReserveCommand>(context.Message));
        }
    }
}
