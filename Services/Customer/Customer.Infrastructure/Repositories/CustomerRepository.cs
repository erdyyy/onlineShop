using CustomerService.Application.Contracts.Persistence;
using CustomerService.Domain.Entities;
using CustomerService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerService.Infrastructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Customer>> GetOrdersByUserName(string name)
        {
            var orderList = await _dbContext.Customers
                                .Where(o => o.Name == name)
                                .ToListAsync();
            return orderList;
        }

        public async Task<Customer> GetProductById(int id)
        {
            var orderList = await _dbContext.Customers
                                .FirstOrDefaultAsync(o => o.Id == id);
                               
            return orderList;
        }
    }
}
