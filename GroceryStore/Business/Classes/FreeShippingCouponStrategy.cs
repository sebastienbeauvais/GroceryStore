using GroceryStore.Business.Interfaces;
using GroceryStore.Models.Interfaces;

namespace GroceryStore.Business.Classes
{
    public class FreeShippingDiscountCouponStrategy : ICouponStrategy
    {
        public double ApplyCoupon(IShoppingCart shoppingCart)
        {
            Console.WriteLine("Applying freeshipping discount...");
            if (shoppingCart.TotalPrice >= 30)
            {
                return shoppingCart.TotalPrice - shoppingCart.coupon.Discount;
            }
            return shoppingCart.TotalPrice;
        }
        public bool IsApplicable(ICoupon coupon)
        {
            return coupon.Id == 3;
        }
    }
}
