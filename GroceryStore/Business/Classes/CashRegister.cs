using GroceryStore.Business.Interfaces;
using GroceryStore.Models.Interfaces;

namespace GroceryStore.Business.Classes
{
    public class CashRegister : ICashRegister
    {
        private ICouponHandler _couponHandler;
        private IShoppingCartBuilder _shoppingCartBuilder;
        public CashRegister(ICouponHandler couponHandler, IShoppingCartBuilder shoppingCartBuilder)
        {
            _couponHandler = couponHandler;
            _shoppingCartBuilder = shoppingCartBuilder;
        }

        public void Checkout()
        {
            var shoppingCart = _shoppingCartBuilder.BuildShoppingCart();
            _couponHandler.HandleUserSelection(shoppingCart);
            Console.WriteLine($"Thank you for shopping with us. Your total was ${shoppingCart.TotalPrice}");
            //Environment.Exit(0);
        }
    }
}
