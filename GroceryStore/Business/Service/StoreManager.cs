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

        private void DisplayInventory(IEnumerable<Item> inventory)
        {
            foreach (var item in inventory)
            {
                Console.WriteLine($"{item.Id}. {item.Name} - ${item.Price:F2}");
            }
        }
        private void DisplayCartItems(IEnumerable<CartItem> cart)
        {
            if (cart.Count() > 0)
            {
                foreach (var item in cart)
                {
                    Console.WriteLine($"{item.Name} - {item.Quantity}");
                }
            }
            else
            {
                Console.WriteLine("Your cart is empty!");
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
            switch (userInput)
            {
                case "1":
                    //TODO - list store inventory
                    var inventory = _inventoryService.GetStoreInventory();
                    DisplayInventory(inventory);
                    break;
                case "2":
                    //TODO - future functionality
                    break;
                case "3":
                    //TODO - get cart items
                    var shoppingCart = _cartService.PrePackagedCart();
                    var storeInventory = _inventoryService.GetStoreInventory();
                    var cartTotal = _cartService.GetCartTotal(shoppingCart, storeInventory);
                    //var cart = _cartService.GetItemsInCart();
                    DisplayCartItems(shoppingCart);
                    Console.WriteLine($"Cart total: {cartTotal}");
                    break;
                case "4":
                    //TODO - checkout
                    
                    break;
            }

        }
    }
}
