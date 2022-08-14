using MediatR;

namespace ProductService.Application.Features.Orders.Commands.DeleteOrder
{
    public class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
