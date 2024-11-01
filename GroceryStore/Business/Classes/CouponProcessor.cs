using GroceryStore.Business.Interfaces;
using GroceryStore.Models.Interfaces;

namespace GroceryStore.Business.Classes
{
    public class CouponProcessor : ICouponProcessor
    {
        private readonly IEnumerable<ICouponStrategy> _couponStrategies;
        public CouponProcessor(IEnumerable<ICouponStrategy> couponStrategies) 
        {
            _couponStrategies = couponStrategies;
        }
        public double ApplyCoupon(IShoppingCart shoppingCart)
        {
            if (shoppingCart.coupon != null)
            {
                foreach (var strategy in _couponStrategies)
                {
                    if (strategy.IsApplicable(shoppingCart.coupon))
                    {
                        shoppingCart.TotalPrice = strategy.ApplyCoupon(shoppingCart);
                        break;
                    }
                }
            }
            return shoppingCart.TotalPrice;
        }
    }
}
