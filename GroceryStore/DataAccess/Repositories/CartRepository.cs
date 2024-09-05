using GroceryStore.DataAccess.Interfaces;
using GroceryStore.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.DataAccess.Repositories
{
    public class CartRepository : ICartRepository
    {
        private static List<CartItem> _cart = new List<CartItem>();
        public IEnumerable<CartItem> GetItemsInCart()
        {
            return _cart;
        }
        public List<CartItem> InitializeStoreCart()
        {
            _cart = new List<CartItem>
            {
                //new CartItem {}
            };
            return _cart;
        }
        public List<CartItem> PrePackagedCart(){
            _cart = new List<CartItem> 
            {
                new CartItem {Name = "White Bread", Quantity = 2},
                new CartItem {Name = "Apple", Quantity = 4},
                new CartItem {Name = "Banana", Quantity = 1},
                new CartItem {Name = "Wagyu Beef", Quantity = 1}
            };
            return _cart;
        }
    }
}
