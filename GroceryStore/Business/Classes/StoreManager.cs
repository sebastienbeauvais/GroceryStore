using GroceryStore.Business.Classes;
using GroceryStore.Business.Interfaces;
using GroceryStore.Models;
using GroceryStore.Models.Interfaces;
using GroceryStore.Data;
using GroceryStore.Data.Interfaces;


namespace GroceryStore.Business.Service
{
    public class StoreManager : IStoreManager
    {
        private ICashRegister _register;
        private IShoppingCartHandler _shoppingCartHandler;
        private List<IStoreItem> _storeDb;
        public StoreManager(ICashRegister register, IShoppingCartHandler shoppingCartHandler, IStoreInventoryDb storeDb) 
        {
            _register = register;
            _shoppingCartHandler = shoppingCartHandler;
            _storeDb = storeDb.Inventory;
        }

        private void DisplayInventory(IEnumerable<IStoreItem> inventory)
        {
            foreach (var item in inventory)
            {
                Console.WriteLine($"{item.Id}. {item.Name} - ${item.Price:F2}");
            }
        }

        public void ShowStoreMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Show store inventory");
            Console.WriteLine("2. Add item(s) to cart");
            Console.WriteLine("3. Show items in your cart");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Leave store");
        }

        public void HandleUserInput(string userInput)
        {            
            switch (userInput)
            {
                case "1":
                    DisplayInventory(_storeDb);
                    break;
                case "2":
                    _shoppingCartHandler.AddItemToShoppingCart();
                    break;
                case "3":
                    _shoppingCartHandler.ShowItemsInShoppingCart();
                    break;
                case "4":
                    _register.Checkout();
                    break;
            }
        }
    }
}
