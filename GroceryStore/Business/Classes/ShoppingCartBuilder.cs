using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Business.Interfaces;
using GroceryStore.Data.Interfaces;
using GroceryStore.Models.Interfaces;
using GroceryStore.Models;

namespace GroceryStore.Business.Classes
{
    public class ShoppingCartBuilder : IShoppingCartBuilder
    {
        private readonly List<IStoreItem> _storeInventory;
        private IShoppingCartHelper _shoppingCartHelper;

        public ShoppingCartBuilder(IStoreInventoryDb storeInventory, IShoppingCartHelper shoppingCartHelper)
        {
            _storeInventory = storeInventory.Inventory;
            _shoppingCartHelper = shoppingCartHelper;
        }
        public IShoppingCart BuildShoppingCart()
        {
            IEnumerable<ICartItem> shoppingCart = _shoppingCartHelper.GetShoppingCartItems();
            double totalPrice = 0;

            foreach (var cartItem in shoppingCart)
            {
                var storeItem = _storeInventory.FirstOrDefault(i => i.Name == cartItem.Name);
                if (storeItem != null)
                {
                    totalPrice += storeItem.Price * cartItem.Quantity;
                }
            }

            return new ShoppingCart
            {
                Items = shoppingCart,
                TotalPrice = totalPrice
            };
        }
    }
}
