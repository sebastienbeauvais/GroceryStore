using GroceryStore.Business.Interfaces;
using GroceryStore.Data.Interfaces;
using GroceryStore.Models.Interfaces;
using GroceryStore.Models;

namespace GroceryStore.Business.Classes
{
    public class ShoppingCartBuilder : IShoppingCartBuilder
    {
        private readonly List<IStoreItem> _storeInventory;
        private IShoppingCartHandler _shoppingCartHandler;

        public ShoppingCartBuilder(IStoreInventoryDb storeInventory, IShoppingCartHandler shoppingCartHandler)
        {
            _storeInventory = storeInventory.Inventory;
            _shoppingCartHandler = shoppingCartHandler;
        }
        public IShoppingCart BuildShoppingCart()
        {
            IEnumerable<ICartItem> shoppingCart = _shoppingCartHandler.GetShoppingCartItems();
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
