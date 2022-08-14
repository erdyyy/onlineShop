using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext)
        {            
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {CustomerFullName = "ahmet çelakan",  CustomerAdress = "Bahcelievler", Country = "Turkey", TotalPrice = 350,CargoTrackingNumer="asldkiaşsdlşailsdiaşsd",
                OrderNumber="11111111",ProductName="IPhone X",ProductPrice=290,TaxAmount =60,Unit=1,CreatedDate = DateTime.Now.AddDays(-7) , OrderDate = Convert.ToDateTime("2022.08.14"),
                },
                    new Order() {CustomerFullName = "erdi çelakan",  CustomerAdress = "Bahcelievler", Country = "Turkey", TotalPrice = 250,CargoTrackingNumer="sdfsdfsdfsdf",
                OrderNumber="22222222",ProductName="IPhone X",ProductPrice=290,TaxAmount =40,Unit=2,CreatedDate = DateTime.Now.AddDays(-10) , OrderDate =Convert.ToDateTime("2022.08.15")}
            };
        }
    }
}
