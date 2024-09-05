using GroceryStore.DataAccess.Models;

namespace GroceryStore.Business.Interfaces
{
    public interface ICartService
    {
        List<CartItem> InitializeStoreCart();
        IEnumerable<CartItem> GetItemsInCart();
        List<CartItem> PrePackagedCart();
        double GetCartTotal(List<CartItem> shoppingCart, IEnumerable<Item> storeInventory);
        void DisplayCartInfo(List<CartItem> shoppingCart, double cartTotal);
    }
}
