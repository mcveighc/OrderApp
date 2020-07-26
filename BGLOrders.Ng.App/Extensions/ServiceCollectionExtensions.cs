using BGLOrderApp.Data;
using BGLOrderApp.Data.Repositories;
using BGLOrderApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BGLOrderApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add dependencies from API project to DI Container
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void AddApiServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IOrderService, OrderService>();
            serviceCollection.AddTransient<IItemService, ItemService>();
        }

        /// <summary>
        /// Add dependencies from Data project to DI Container
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void AddDataServices(this IServiceCollection serviceCollection, IConfiguration config)
        {
            serviceCollection.AddTransient<IOrderRepository, OrderRepository>();
            serviceCollection.AddTransient<IItemRepository, ItemRepository>(); ;

            var connectionString = config.GetConnectionString("BGLOrders");
            // Register DBContext and setup connection pooling
            serviceCollection.AddDbContextPool<OrdersDbContext>(opts => opts.UseSqlServer(connectionString).EnableSensitiveDataLogging(), 10);
        }
    }
}
