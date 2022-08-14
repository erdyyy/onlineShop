using CustomerService.Application.Features.AddCustomer.Commands;
using FluentValidation;


namespace Ordering.Application.Features.Customer.Commands.AddCustomer
{
    public class AddCustomerCommandValidator : AbstractValidator<AddCustomerCommand>
    {
        public AddCustomerCommandValidator()
        {
     
        }
    }
}
