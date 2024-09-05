using GroceryStore.DataAccess.Models;

namespace GroceryStore.Business.Interfaces
{
    public interface ICartService
    {
        List<CartItem> InitializeStoreCart();
        IEnumerable<CartItem> GetItemsInCart();
    }
}
