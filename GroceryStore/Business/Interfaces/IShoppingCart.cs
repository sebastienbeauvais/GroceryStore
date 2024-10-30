using GroceryStore.Models.Interfaces;

namespace GroceryStore.Business.Interfaces
{
    public interface IShoppingCart
    {
        public void AddItemToShoppingCart(IEnumerable<IStoreItem> storeInventory);
        public void ShowItemsInShoppingCart(IEnumerable<IStoreItem> storeInventory);
        public IEnumerable<ICartItem> GetShoppingCartItems();
        public double GetCartTotal(IEnumerable<IStoreItem> storeInventory, IEnumerable<ICartItem> shoppingCart);
    }
}
