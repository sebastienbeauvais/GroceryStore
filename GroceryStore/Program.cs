using GroceryStore.Business.Classes;
using GroceryStore.Business.Interfaces;
using GroceryStore.Business.Service;
using GroceryStore.Data;
using GroceryStore.Data.Interfaces;
using GroceryStore.Presentation;
using Microsoft.Extensions.DependencyInjection;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();

            var storeManager = serviceProvider.GetRequiredService<GroceryStore.Presentation.GroceryStore>();

            
            storeManager.EnterStore();
        }

        private static ServiceProvider ConfigureServices()
        {
            // Set up dependency injection
            var services = new ServiceCollection();

            // Register services
            services.AddScoped<GroceryStore.Presentation.GroceryStore, GroceryStore.Presentation.GroceryStore>();
            services.AddScoped<IStoreManager, StoreManager>();
            services.AddScoped<ICouponProcessor, CouponProcessor>();
            services.AddScoped<ICouponStrategy, TenOffDiscountCouponStrategy>();
            services.AddScoped<ICouponStrategy, BogoFreeCouponStrategy>();
            services.AddScoped<ICashRegister, CashRegister>();
            services.AddScoped<IShoppingCartHandler, ShoppingCartHandler>();
            services.AddScoped<ICouponHandler, CouponHandler>();
            services.AddSingleton<IStoreInventoryDb, StoreInventoryDb>();
            services.AddSingleton<ICouponDb, CouponDb>();
            services.AddScoped<IShoppingCartBuilder, ShoppingCartBuilder>();

            return services.BuildServiceProvider();
        }
    }
}