using System.Linq;
using GroceryStore.Business.Interfaces;
using GroceryStore.DataAccess.Interfaces;
using GroceryStore.DataAccess.Models;
using Microsoft.VisualBasic;

namespace GroceryStore.Business.Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public IEnumerable<CartItem> GetItemsInCart()
        {
            if(_cartRepository.GetItemsInCart().Count() > 0)
            {
                return _cartRepository.GetItemsInCart();
            }
            else
            {
                InitializeStoreCart();
                return _cartRepository.GetItemsInCart();
            }
        }
        public List<CartItem> PrePackagedCart(){
            // takes user input
            // based on input a pre-made cart is selected
            return _cartRepository.PrePackagedCart();
        }

        public List<CartItem> InitializeStoreCart()
        {
            return _cartRepository.InitializeStoreCart();
        }

        public double GetCartTotal(List<CartItem> shoppingCart, IEnumerable<Item> storeInventory)
        {
            double total = 0;
            foreach(var cartItem in shoppingCart){
                var itemName = cartItem.Name;
                var itemQuantity = cartItem.Quantity;
                var matchingItem = storeInventory.FirstOrDefault(x => x.Name == itemName);
                if (matchingItem != null){
                    total += matchingItem.Price * itemQuantity;
                }
            }
            return total;
        }

        public void DisplayCartInfo(List<CartItem> shoppingCart, double cartTotal)
        {
            Console.WriteLine("-------- YOUR SHOPPING CART ---------");
            foreach(var cartItem in shoppingCart){
                Console.WriteLine($"{cartItem.Name} - Quantity: {cartItem.Quantity}");
            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Total: {cartTotal}");
        }
    }
}
