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

        public void Checkout(IShoppingCart shoppingCart)
        {
            var newCartTotal = _couponHandler.HandleUserSelection(shoppingCart);
            Console.WriteLine($"Thank you for shopping with us. Your total was ${newCartTotal}");
            //Console.WriteLine($"And you saved: ${shoppingCart.TotalPrice - newCartTotal}");
            //Environment.Exit(0);
        }
    }
}
