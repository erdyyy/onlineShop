using Microsoft.EntityFrameworkCore;
using Product.Application.Contracts.Persistence;

using Product.Infrastructure.Persistence;
using Product.Infrastructure.Repositories;
using ProductService.Application.Contracts.Persistence;
using ProductService.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Domain.Entities.Product>, IProductRepository
    {
        public ProductRepository(ProductContext dbContext) : base(dbContext)
        {
        }

        public async Task<Domain.Entities.Product> GetOrdersByName(string name)
        {
            var order = await _dbContext.Products
                                .Where(o => o.Name == name)
                                .FirstOrDefaultAsync();
            return order;
        }

        public async Task<Domain.Entities.Product> GetProductById(int id)
        {
            var orderList = await _dbContext.Products
                                .FirstOrDefaultAsync(o => o.Id == id);
                               
            return orderList;
        }
    }
}
