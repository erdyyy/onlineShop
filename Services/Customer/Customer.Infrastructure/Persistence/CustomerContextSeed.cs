using CustomerService.Domain.Entities;
using CustomerService.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Product.Infrastructure.Persistence
{
    public class CustomerContextSeed
    {
        public static async Task SeedData(CustomerContext productContext)
        {
            bool existProduct = productContext.Customers.Any();
            if (!existProduct)
            {
                productContext.AddRange(GetPreconfiguredProducts());
                await productContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Customer> GetPreconfiguredProducts()
        {
            return new List<Customer>()
            {
                new Customer()
                {
                          Adress="ankara yenimahalle ",
                          Email="asd@hotmail.com",
                          LastName="akkaya",
                          Name="ahmet",
                          PhoneNumber="0-555-55-55",
                          CreatedDate=DateTime.Now

                },
                new  Customer()
                {
                          Adress="istanbul yenimahalle ",
                          Email="asd@hotmail.com",
                          LastName="akkaya",
                          Name="mehmet",
                          PhoneNumber="0-555-55-55",
                          CreatedDate=DateTime.Now

                }

            };
        }
    }
}
