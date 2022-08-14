using FluentValidation;
using ProductService.Application.Features.Product.Commands;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class ProductReserveCommandValidator : AbstractValidator<ProductReserveCommand>
    {
        public ProductReserveCommandValidator()
        {
            RuleFor(p => p.Unit).GreaterThan(0).WithMessage("Must be added one product");
        }
    }
}
