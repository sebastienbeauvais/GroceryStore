using GroceryStore.Models.Interfaces;

namespace GroceryStore.Business.Interfaces
{
    public interface ICashRegister
    {
        public void Checkout(IEnumerable<ICartItem> shoppingCart, double shoppingCartTotal);
    }
}
