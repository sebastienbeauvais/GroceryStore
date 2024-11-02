using GroceryStore.Business.Interfaces;
using GroceryStore.Models.Interfaces;
using GroceryStore.Models;
using System.Xml.Serialization;

namespace GroceryStore.Business.Classes
{
    public class ShoppingCartHelper : IShoppingCartHelper
    {
        public ShoppingCartHelper() { } //here we would have a builder. We could all a attrubute for Cart {get;} -> would do line 57+58 on storeManager

        List<ICartItem> shoppingCart = new List<ICartItem>();
        public void AddItemToShoppingCart(IEnumerable<IStoreItem> storeInventory)
        {
            Console.WriteLine("Please enter the ID of the item you would like to add: ");
            var cartItemToAdd = Convert.ToInt32(Console.ReadLine());
            var searchInventory = storeInventory.ToList().Find(x => x.Id == cartItemToAdd);
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
        public void ShowItemsInShoppingCart(IEnumerable<IStoreItem> storeInventory) 
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


        public double GetCartTotal(IEnumerable<IStoreItem> storeInventory, IEnumerable<ICartItem> shoppingCart)
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
                    cartItem.Price = matchingItem.Price;
                }
            }
            return cartTotal;
        }
        public List<ICartItem> GetShoppingCartItems()
        {
            return shoppingCart; 
        }
    }
}
