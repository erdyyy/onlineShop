using Product.Application.Contracts.Persistence;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application.Contracts.Persistence
{
    public interface IProductRepository : IAsyncRepository<Domain.Entities.Product>
    {
        Task<Domain.Entities.Product> GetOrdersByName(string name);
        Task<Domain.Entities.Product> GetProductById(int id);
    }
}
