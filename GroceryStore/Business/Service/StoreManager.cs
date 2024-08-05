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

        public StoreManager(IInventoryService inventoryService) 
        {
            _inventoryService = inventoryService;
        }

        private void InitializeInventory()
        {
            _inventoryService.InitializeStoreInventory();
        }
        //Move to different layer?
        private void DisplayInventory(IEnumerable<Item> inventory)
        {
            foreach (var item in inventory)
            {
                Console.WriteLine($"{item.Id}. {item.Name} - ${item.Price:F2}");
            }
        }

        public void ShowStoreMenu()
        {
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
                    //TODO - list store inventory
                    var inventory = _inventoryService.GetStoreInventory();
                    DisplayInventory(inventory);
                    break;
                case "2":
                    //TODO - add item to cart
                    break;
                case "3":
                    //TODO - get cart items
                    break;
                case "4":
                    //TODO - checkout
                    break;
            }

        }
    }
}
