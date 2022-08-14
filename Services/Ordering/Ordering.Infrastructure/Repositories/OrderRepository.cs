using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetOrderDateRange(DateTime StartDate, DateTime EndDate)
        {
            var orderList = await _dbContext.Orders
                                .Where(o => o.OrderDate >= StartDate.Date && o.OrderDate<= EndDate.Date)
                                .ToListAsync();
            return orderList;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                                .Where(o => o.CustomerFullName == userName)
                                .ToListAsync();
            return orderList;
        }
    }
}
