using GroceryStore.Business.Interfaces;
using GroceryStore.Models.Interfaces;
using GroceryStore.Models;
using GroceryStore.Data.Interfaces;

namespace GroceryStore.Business.Classes
{
    public class ShoppingCartHandler : IShoppingCartHandler
    {
        private IEnumerable<IStoreItem> _storeDb;
        public ShoppingCartHandler(IStoreInventoryDb storeDb) 
        {
            _storeDb = storeDb.Inventory;
        }

        List<ICartItem> shoppingCart = new List<ICartItem>();
        public void AddItemToShoppingCart()
        {
            Console.WriteLine("Please enter the ID of the item you would like to add: ");
            var cartItemToAdd = Convert.ToInt32(Console.ReadLine());
            var searchInventory = _storeDb.ToList().Find(x => x.Id == cartItemToAdd);
            if (searchInventory != null)
            {
                // Check if item is already in the cart
                ICartItem cartItem = shoppingCart.Find(x => x.Name == searchInventory.Name);
                if (cartItem != null)
                {
                    cartItem.Quantity++;
                }
                else
                {
                    shoppingCart.Add(new CartItem { Name = searchInventory.Name, Quantity = 1 });
                }
            }
        }
        public void ShowItemsInShoppingCart() 
        {            
            Console.WriteLine("-------- YOUR SHOPPING CART ---------");
            foreach (var item in shoppingCart)
            {
                Console.WriteLine($"{item.Name} - Quantity: {item.Quantity}");
            }
            Console.WriteLine("-------------------------------------");
        }

        public List<ICartItem> GetShoppingCartItems()
        {
            return shoppingCart; 
        }
    }
}
