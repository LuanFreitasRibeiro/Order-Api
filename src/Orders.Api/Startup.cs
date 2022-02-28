using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Orders.AppService.Services;
using Orders.AppService.Validators;
using Orders.Data;
using Orders.Domain.Inferfaces.Repositories;
using Orders.Domain.Inferfaces.Services;
using Orders.Domain.Models;
using Orders.Domain.Models.Request.Customer;
using Orders.Domain.Models.Request.Order;
using Orders.Domain.Models.Response.CustomerResponse;
using Orders.Domain.Models.Response.OrderResponse;
using Orders.Respository;

namespace Orders.Api
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

            services.AddControllers();

            services.AddDbContext<StoreDataContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));
            services.AddTransient<StoreDataContext, StoreDataContext>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerResponse>();
                cfg.CreateMap<Customer, CustomerOrdersResponse>();
                cfg.CreateMap<OrderRequest, Order>();
                cfg.CreateMap<Order, OrderRequest>();
                cfg.CreateMap<Order, CreateOrderResponse>();

            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddSingleton<IValidator<CustomerRequest>, CreateCustomerValidator>();
            services.AddSingleton<IValidator<OrderRequest>, CreateOrderValidator>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Orders.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Orders.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
