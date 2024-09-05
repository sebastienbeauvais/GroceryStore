using GroceryStore.DataAccess.Interfaces;
using GroceryStore.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.DataAccess.Repositories
{
    public class CartRepository :ICartRepository
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
        //Add pre-populated cart
    }
}
