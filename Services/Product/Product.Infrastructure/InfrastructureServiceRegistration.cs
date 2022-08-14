using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Application.Contracts.Persistence;
using Product.Infrastructure.Persistence;
using Product.Infrastructure.Repositories;
using ProductService.Application.Contracts.Persistence;
using ProductService.Infrastructure.Persistence;
using ProductService.Infrastructure.Repositories;

namespace ProductService.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {            
            services.AddDbContext<ProductContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Db"),b => b.MigrationsAssembly("Product.API")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));                        
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
