using CustomerService.Application.Contracts.Persistence;
using CustomerService.Infrastructure.Persistence;
using CustomerService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CustomerService.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddDbContext<CustomerContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Db"),b => b.MigrationsAssembly("Customer.API")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));                        
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}
