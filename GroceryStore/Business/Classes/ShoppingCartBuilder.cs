using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Business.Interfaces;
using GroceryStore.Data.Interfaces;
using GroceryStore.Models.Interfaces;

namespace GroceryStore.Business.Classes
{
    public class ShoppingCartBuilder : IShoppingCartBuilder
    {
        private readonly List<IStoreItem> _storeInventory;
        //private readonly List<ICartItem> _shoppingCartItems;

        public ShoppingCartBuilder(IStoreInventoryDb storeInventory)
        {
            //_shoppingCartItems = shoppingCartItems;
            _storeInventory = storeInventory.Inventory;
        }
        public IShoppingCart BuildShoppingCart(IEnumerable<ICartItem> shoppingCartItems)
        {
            double totalPrice = 0;

            foreach (var cartItem in shoppingCartItems)
            {
                var storeItem = _storeInventory.FirstOrDefault(i => i.Name == cartItem.Name);
                if (storeItem != null)
                {
                    totalPrice += storeItem.Price * cartItem.Quantity;
                }
            }

            return new ShoppingCart
            {
                Items = shoppingCartItems,
                TotalPrice = totalPrice
            };
        }
    }
}
