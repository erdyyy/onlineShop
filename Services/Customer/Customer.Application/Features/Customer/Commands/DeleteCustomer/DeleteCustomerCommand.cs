using MediatR;

namespace CustomerService.Application.Features.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public int Id { get; set; }
    }
}
