using Microsoft.Extensions.DependencyInjection;
using OnlineStoreApplication.Repository;
using OnlineStoreApplication.Service;

namespace OnlineStoreApplication
{
    public static class RegisterServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCatgoryRepository, ProductCatgoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderProcductRepository, OrderProcductRepository>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductCatgoryService, ProductCatgoryService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderProductService, OrderProductService>();

            services.AddScoped<ICustomerUnitOfWork, CustomerUnitOfWork>();

            services.AddScoped<IAuthService, AuthService>();

        }
    }
}
