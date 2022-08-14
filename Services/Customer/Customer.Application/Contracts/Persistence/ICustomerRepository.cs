using CustomerService.Application.Contracts.Persistence;
using CustomerService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetOrdersByUserName(string userName);
        Task<Customer> GetProductById(int id);
    }
}
