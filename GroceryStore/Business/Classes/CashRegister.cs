using GroceryStore.Business.Interfaces;
using GroceryStore.Models.Interfaces;

namespace GroceryStore.Business.Classes
{
    public class CashRegister : ICashRegister
    {
        private ICouponHandler _couponHandler;
        public CashRegister(ICouponHandler couponHandler)
        {
            _couponHandler = couponHandler;
        }

        public void Checkout(IEnumerable<ICartItem> shoppingCart, double shoppingCartTotal)
        {
            var newCartTotal = _couponHandler.HandleUserSelection(shoppingCart, shoppingCartTotal);
            Console.WriteLine($"Thank you for shopping with us. Your total was ${newCartTotal}");
            Console.WriteLine($"And you saved: ${shoppingCartTotal - newCartTotal}");
            //Environment.Exit(0);
        }
    }
}
