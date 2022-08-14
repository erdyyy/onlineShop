using CustomerService.Application.Features.Customer.Commands.UpdateCustomer;
using FluentValidation;
using ProductService.Application.Features.Orders.Commands.UpdateOrder;

namespace ProductService.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");

        }
    }
}
