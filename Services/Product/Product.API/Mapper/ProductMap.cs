using AutoMapper;
using EventBus.Messages.Events;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;
using ProductService.Application.Features.Product.Commands;

namespace Ordering.API.Mapper
{
    public class ProductMap : Profile
	{
		public ProductMap()
		{
			CreateMap<OrderComplateEvent,ProductReserveCommand>().ReverseMap();
		}
	}
}
