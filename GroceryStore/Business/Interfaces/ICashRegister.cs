using GroceryStore.Models.Interfaces;

namespace GroceryStore.Business.Interfaces
{
    public interface ICashRegister
    {
        public void Checkout(IShoppingCart shoppingCart);
    }
}
