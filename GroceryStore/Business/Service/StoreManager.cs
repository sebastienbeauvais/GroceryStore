using GroceryStore.Business.Interfaces;
using GroceryStore.DataAccess.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;


namespace GroceryStore.Business.Service
{
    public class StoreManager : IStoreManager
    {
        //Initialize some repository class?
        IInventoryService _inventoryService;
        ICartService _cartService;

        public StoreManager(IInventoryService inventoryService, ICartService cartService)
        {
            _inventoryService = inventoryService;
            _cartService = cartService;
         }

        private void InitializeInventory()
        {
            _inventoryService.InitializeStoreInventory();
        }
        private void InitializeCart() 
        {
            _cartService.InitializeStoreCart();
        }

        private void DisplayInventory(IEnumerable<Item1> inventory)
        {
            foreach (var item in inventory)
            {
                Console.WriteLine($"{item.Id}. {item.Name} - ${item.Price:F2}");
            }
        }

        public void ShowStoreMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("1. Show store inventory");
            Console.WriteLine("2. Add item(s) to cart");
            Console.WriteLine("3. Select pre-packaged shopping cart");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Leave store");
            Console.WriteLine("\n");
        }
        public void HandleUserInput(string userInput)
        {            
            // Since we use inventory in multiple cases we can create it once and use it where needed
            var inventory = _inventoryService.GetStoreInventory();
            
            switch (userInput)
            {
                case "1":
                    DisplayInventory(inventory);
                    break;
                case "2":
                    //TODO - future functionality
                    Console.WriteLine("Feature coming soon!!");
                    break;
                case "3":
                    // this can probably be cleaned up. I dont think we need a private method
                    // to display the cart items. In addition we can probably consolidate all
                    // these method calls into a single Helper and call them there
                    var shoppingCart = _cartService.PrePackagedCart();
                    var cartTotal = _cartService.GetCartTotal(shoppingCart, inventory);
                    _cartService.DisplayCartInfo(shoppingCart, cartTotal);
                    //DisplayCartItems(shoppingCart);
                    //Console.WriteLine($"Cart total: {cartTotal}");
                    break;
                case "4":
                    //TODO - checkout
                    
                    break;
            }

        }
    }
}
