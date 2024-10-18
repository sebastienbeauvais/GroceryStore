using GroceryStore.Business.Interfaces;
using GroceryStore.Models;

namespace GroceryStore.Business.Classes
{
    public class NoCouponStrategy : ICouponStrategy
    {
        public double ApplyCoupon(IEnumerable<CartItem> shoppingCart, double shoppingCartTotal, Coupon coupon)
        {
            Console.WriteLine("No Coupon Applied...");
            return shoppingCartTotal;
        }
    }
}
