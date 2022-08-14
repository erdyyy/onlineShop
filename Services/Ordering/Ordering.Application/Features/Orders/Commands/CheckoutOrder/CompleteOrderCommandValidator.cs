using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CompleteOrderCommandValidator : AbstractValidator<CompleteOrderCommand>
    {
        public CompleteOrderCommandValidator()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty().WithMessage("{ProductName} is required.")
                .NotNull()
                .WithMessage("{UserName} must not exceed 50 characters.");

                RuleFor(p => p.CustomerAdress)
               .NotEmpty().WithMessage("{CustomerAdress} is required.");

            RuleFor(p => p.TotalPrice)
                .NotEmpty().WithMessage("{TotalPrice} is required.")
                .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero.");
        }
    }
}
