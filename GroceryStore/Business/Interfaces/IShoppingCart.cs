using GroceryStore.Models;

namespace GroceryStore.Business.Interfaces
{
    public interface IShoppingCart
    {
        public void AddItemToShoppingCart(IEnumerable<StoreItem> storeInventory);
        public void ShowItemsInShoppingCart(IEnumerable<StoreItem> storeInventory);
        public IEnumerable<CartItem> GetShoppingCartItems();
    }
}
