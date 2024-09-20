using GroceryStore.Business.Interfaces;
using GroceryStore.Models;
using System.Xml.Serialization;

namespace GroceryStore.Business.Classes
{
    public class ShoppingCart : IShoppingCart
    {
        public ShoppingCart() { }

        List<CartItem> shoppingCart = new List<CartItem>();
        public void AddItemToShoppingCart(IEnumerable<StoreItem> storeInventory)
        {
            Console.WriteLine("Please enter the ID of the item you would like to add: ");
            var cartItemToAdd = Convert.ToInt32(Console.ReadLine());
            var searchInventory = storeInventory.ToList().Find(x => x.Id == cartItemToAdd);
            if (searchInventory != null)
            {
                // Check if item is already in the cart
                CartItem cartItem = shoppingCart.Find(x => x.Name == searchInventory.Name);
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
        public void ShowItemsInShoppingCart(IEnumerable<StoreItem> storeInventory) 
        {
            var cartTotal = GetCartTotal(storeInventory, shoppingCart);
            

            Console.WriteLine("-------- YOUR SHOPPING CART ---------");
            foreach (var item in shoppingCart)
            {
                Console.WriteLine($"{item.Name} - Quantity: {item.Quantity}");
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Total: {cartTotal}");
        }


        public double GetCartTotal(IEnumerable<StoreItem> storeInventory, IEnumerable<CartItem> shoppingCart)
        {
            var cartTotal = 0.0;
            foreach (var cartItem in shoppingCart)
            {
                var itemName = cartItem.Name;
                var itemQuantity = cartItem.Quantity;
                var matchingItem = storeInventory.FirstOrDefault(x => x.Name == itemName);
                if (matchingItem != null)
                {
                    cartTotal += matchingItem.Price * itemQuantity;
                }
            }
            return cartTotal;
        }
        public IEnumerable<CartItem> GetShoppingCartItems()
        {
            return shoppingCart; 
        }
    }
}
