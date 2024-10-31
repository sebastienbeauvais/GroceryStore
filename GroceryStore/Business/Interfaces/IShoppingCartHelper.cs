using GroceryStore.Models.Interfaces;

namespace GroceryStore.Business.Interfaces
{
    public interface IShoppingCartHelper
    {
        public void AddItemToShoppingCart(IEnumerable<IStoreItem> storeInventory);
        public void ShowItemsInShoppingCart(IEnumerable<IStoreItem> storeInventory);
        public List<ICartItem> GetShoppingCartItems();
        public double GetCartTotal(IEnumerable<IStoreItem> storeInventory, IEnumerable<ICartItem> shoppingCart);
    }
}
