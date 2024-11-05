using GroceryStore.Models.Interfaces;

namespace GroceryStore.Business.Interfaces
{
    public interface IShoppingCartHandler
    {
        public void AddItemToShoppingCart();
        public void ShowItemsInShoppingCart();
        public List<ICartItem> GetShoppingCartItems();
    }
}
