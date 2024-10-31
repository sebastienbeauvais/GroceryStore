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
        private IShoppingCartHelper _shoppingCartHelper;
        private List<IStoreItem> _storeDb;
        private IShoppingCartBuilder _shoppingCartBuilder;
        public StoreManager(ICashRegister register, IShoppingCartHelper shoppingCartHelper, IStoreInventoryDb storeDb, IShoppingCartBuilder shoppingCartBuilder) 
        {
            _register = register;
            _shoppingCartHelper = shoppingCartHelper;
            _storeDb = storeDb.Inventory;
            _shoppingCartBuilder = shoppingCartBuilder;
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
                    _shoppingCartHelper.AddItemToShoppingCart(_storeDb);
                    break;
                case "3":
                    _shoppingCartHelper.ShowItemsInShoppingCart(_storeDb);
                    break;
                case "4":
                    var shoppingCartItems = _shoppingCartHelper.GetShoppingCartItems();
                    var shoppingCart = _shoppingCartBuilder.BuildShoppingCart(shoppingCartItems);

                    _register.Checkout(shoppingCart);//shoppingCartItems, _shoppingCart.GetCartTotal(_storeDb, shoppingCartItems)); //Then pass shoppingCart by itself into this
                    break;
            }
        }
    }
}
