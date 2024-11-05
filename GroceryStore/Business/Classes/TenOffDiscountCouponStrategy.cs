using GroceryStore.Business.Interfaces;
using GroceryStore.Models.Interfaces;

namespace GroceryStore.Business.Classes
{
    public class TenOffDiscountCouponStrategy : ICouponStrategy
    {
        public double ApplyCoupon(IShoppingCart shoppingCart)
        {
            Console.WriteLine("Applying flat discount coupon...");
            return shoppingCart.TotalPrice - (shoppingCart.TotalPrice * shoppingCart.coupon.Discount);
        }
        public bool IsApplicable(ICoupon coupon)
        {
            return coupon.Id == 1;
        }
    }
}
