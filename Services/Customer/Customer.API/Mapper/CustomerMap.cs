using AutoMapper;
using CustomerService.Application.Features.AddCustomer.Commands;
using EventBus.Messages.Events;


namespace Ordering.API.Mapper
{
    public class CustomerMap : Profile
	{
		public CustomerMap()
		{
			CreateMap<AddCustomerCommand,CustomerService.Domain.Entities.Customer>().ReverseMap();
		}
	}
}
