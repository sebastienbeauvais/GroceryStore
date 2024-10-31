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
            //var selectedCoupon = availableCoupons.FirstOrDefault(x => x.Id == shoppingCart.coupon.Id);

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
        public void ShowAvailableCoupons(IEnumerable<ICoupon> availableCoupons)
        {
            foreach (var coupon in availableCoupons)
            {
                Console.WriteLine($"{coupon.Id} - {coupon.Name}, {coupon.Description}");
            }
        }
        private int GetCouponIdForStrategy(ICouponStrategy strategy)
        {
            //Change this to fetching Enum
            
            if (strategy is TenOffDiscountCouponStrategy) return 1;
            if (strategy is BogoFreeCouponStrategy) return 2;

            throw new InvalidOperationException("Unknown coupon strategy.");
        }
    }
}
