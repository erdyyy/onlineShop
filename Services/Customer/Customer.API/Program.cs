using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

using ProductService.API.Extensions;
using Product.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using CustomerService.Infrastructure.Persistence;

namespace ProductService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<CustomerContext>();
                context.Database.Migrate();
                CustomerContextSeed.SeedData(context).Wait();

                host.MigrateDatabase<CustomerContext>((context, services) =>
                    {
     
                    }).Run();
            }


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
