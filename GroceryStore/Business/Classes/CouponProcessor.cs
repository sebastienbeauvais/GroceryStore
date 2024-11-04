using GroceryStore.Business.Interfaces;
using GroceryStore.Models.Interfaces;

namespace GroceryStore.Business.Classes
{
    public class CouponProcessor : ICouponProcessor
    {
        public CouponProcessor() { }
        public double ApplyCoupon(IShoppingCart shoppingCart)
        {
            if (shoppingCart.coupon != null && shoppingCart.coupon.CouponStrategy != null)
            {
                shoppingCart.TotalPrice = shoppingCart.coupon.CouponStrategy.ApplyCoupon(shoppingCart);
            }
            return shoppingCart.TotalPrice;
        }
    }
}
