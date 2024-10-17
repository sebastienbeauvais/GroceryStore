using GroceryStore.Business.Interfaces;
using GroceryStore.Business.Service;


namespace GroceryStore.Presentation
{
    public class GroceryStore
    {
        private readonly IStoreManager _storeManager;
        public GroceryStore(IStoreManager storeManager)
        {
            _storeManager = storeManager;
        }
        public void EnterStore()
        {
            Console.WriteLine("Welcome to the Grocery Store! Please let us know what you would like to do\n");

            string userInput = "default";
            while (userInput != "5")
            {
                _storeManager.ShowStoreMenu();
                userInput = Console.ReadLine();
                _storeManager.HandleUserInput(userInput);
            }

            Console.WriteLine("\nThank you for coming to the store. Please come again!");

        }
    }
}
