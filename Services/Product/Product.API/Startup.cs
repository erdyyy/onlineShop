using EventBus.Messages.Common;
using HealthChecks.UI.Client;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProductService.API.EventBusConsumer;
using ProductService.Application;
using ProductService.Infrastructure;
using ProductService.Infrastructure.Persistence;

namespace ProductService.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
      
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices();
            services.AddInfrastructureServices(Configuration);

            // MassTransit-RabbitMQ Configuration
            services.AddMassTransit(config =>
            {

                config.AddConsumer<ProductReserveConsumer>();

                config.UsingRabbitMq((ctx, cfg) =>
                {
                            
                    //cfg.Host(Configuration["EventBusSettings:HostAddress"]);
                    cfg.Host("rabbitmq");
                    cfg.ReceiveEndpoint(EventBusConstants.OrderComplate, c =>
                    {
                        c.AutoDelete = true;
                        c.ConfigureConsumer<ProductReserveConsumer>(ctx);
                    });
                });
            });
            services.AddMassTransitHostedService();

            // General Configuration
            services.AddScoped<ProductReserveConsumer>();
            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product API", Version = "v1" });
            });
  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API v1"));

            app.UseCors(builder => builder
         .AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader()
   );

           // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); ;
            });
        }
    }
}
