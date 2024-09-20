using GroceryStore.Models;

namespace GroceryStore.Business.Interfaces
{
    public interface ICashRegister
    {
        public void Checkout(IEnumerable<CartItem> shoppingCart, double shoppingCartTotal);
    }
}
