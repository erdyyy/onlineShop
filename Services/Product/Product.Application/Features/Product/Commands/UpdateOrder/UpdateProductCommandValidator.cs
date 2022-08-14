using FluentValidation;
using ProductService.Application.Features.Orders.Commands.UpdateOrder;

namespace ProductService.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} must not exceed 50 characters.");

        }
    }
}
