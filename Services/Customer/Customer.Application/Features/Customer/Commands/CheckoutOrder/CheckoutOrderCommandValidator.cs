using FluentValidation;

namespace ProductService.Application.Features.Orders.Commands.CheckoutOrder
{
    public class ProductReserveCommandValidator : AbstractValidator<ProductService.Application.Features.Product.Commands.ProductReserveCommand>
    {
        public ProductReserveCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{Name} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{Name} must not exceed 10 characters.");           
        }
    }
}
