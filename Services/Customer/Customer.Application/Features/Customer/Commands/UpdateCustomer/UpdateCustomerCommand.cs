using MediatR;

namespace CustomerService.Application.Features.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}