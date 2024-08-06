using GroceryStore.Business.Interfaces;
using GroceryStore.Business.Service;
using GroceryStore.DataAccess.Repositories;


namespace GroceryStore.Presentation
{
    class GroceryStore
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grocery Store! Please let us know what you would like to do\n");

            #region Class Instatiation
            // Preparing for dependencies
            var inventoryRepository = new InventoryRepository();
            var inventoryService = new InventoryService(inventoryRepository);

            IStoreManager storeManager = new StoreManager(inventoryService);
            #endregion

            string userInput = "default";
            while (userInput != "5")
            {
                storeManager.ShowStoreMenu();
                userInput = Console.ReadLine();
                storeManager.HandleUserInput(userInput);
            }

            Console.WriteLine("Thank you for coming to the store. Please come again!");
            return;
        }
    }
}
