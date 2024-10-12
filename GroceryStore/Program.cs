using GroceryStore.Business.Classes;
using GroceryStore.Business.Interfaces;
using GroceryStore.Business.Service;

namespace GroceryStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Build the service provider and configure DI
            var serviceProvider = ConfigureServices();

            // Resolve IStoreManager from DI container
            var storeManager = serviceProvider.GetRequiredService<IStoreManager>();

            // Call Grocery Store logic
            RunGroceryStore(storeManager);
        }

        private static void RunGroceryStore(IStoreManager storeManager)
        {
            Console.WriteLine("Welcome to the Grocery Store! Please let us know what you would like to do\n");

            string userInput = "default";
            while (userInput != "5")
            {
                storeManager.ShowStoreMenu();
                userInput = Console.ReadLine();
                storeManager.HandleUserInput(userInput);
            }

            Console.WriteLine("\nThank you for coming to the store. Please come again!");
        }

        private static ServiceProvider ConfigureServices()
        {
            // Set up dependency injection
            var services = new ServiceCollection();

            // Register services (StoreManager, CouponProcessor, etc.)
            services.AddScoped<IStoreManager, StoreManager>();
            services.AddScoped<ICouponProcessor, CouponProcessor>();
            services.AddScoped<ICouponStrategy, StandardDiscountCouponStrategy>();
            services.AddScoped<ICouponStrategy, BOGOFreeCouponStrategy>();

            // Build the service provider
            return services.BuildServiceProvider();
        }
    }
}