using GroceryStore.Business.Classes;
using GroceryStore.Business.Interfaces;
using GroceryStore.Models;


namespace GroceryStore.Business.Service
{
    public class StoreManager : IStoreManager
    {
        public StoreManager() { }
        IShoppingCart cart = new ShoppingCart();
        ICashRegister register = new CashRegister();

        private List<StoreItem> storeInventoryDb = new List<StoreItem>() {
                new StoreItem { Id = 1, Name = "Apple", Price = 0.50 },
                new StoreItem { Id = 3, Name = "Carrot", Price = 0.10 },
                new StoreItem { Id = 4, Name = "Tomato", Price = 0.30 },
                new StoreItem { Id = 5, Name = "Milk", Price = 1.50 },
                new StoreItem { Id = 2, Name = "Banana", Price = 0.20 },
                new StoreItem { Id = 6, Name = "White Bread", Price = 3.00 },
                new StoreItem { Id = 7, Name = "Whole Wheat Bread", Price = 3.50 },
                new StoreItem { Id = 8, Name = "Eggs (12)", Price = 7.99 },
                new StoreItem { Id = 9, Name = "Eggs (6)", Price = 4.50 },
                new StoreItem { Id = 10, Name = "Coffee Beans", Price = 3.39 },
                new StoreItem { Id = 11, Name = "Brown Sugar", Price = 4.59 },
                new StoreItem { Id = 12, Name = "Oatmeal", Price = 5.99 },
                new StoreItem { Id = 13, Name = "Peanut Butter", Price = 2.50 },
                new StoreItem { Id = 14, Name = "Oat Milk", Price = 4.50 },
                new StoreItem { Id = 15, Name = "Cheddar Cheese", Price = 4.49 },
                new StoreItem { Id = 16, Name = "Salmon", Price = 15.99 },
                new StoreItem { Id = 17, Name = "Chicken", Price = 12.99 },
                new StoreItem { Id = 18, Name = "Wagyu Beed", Price = 105.99 }
            };
        private void DisplayInventory(IEnumerable<StoreItem> inventory)
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
                    DisplayInventory(storeInventoryDb);
                    break;
                case "2":
                    cart.AddItemToShoppingCart(storeInventoryDb);
                    break;
                case "3":
                    cart.ShowItemsInShoppingCart(storeInventoryDb);
                    break;
                case "4":
                    //TODO - checkout
                    var shoppingCart = cart.GetShoppingCartItems();
                    register.Checkout(shoppingCart);
                    break;
            }

        }
    }
}
