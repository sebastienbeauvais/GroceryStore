using GroceryStore.Business.Interfaces;
using GroceryStore.Models.Interfaces;

namespace GroceryStore.Business.Classes
{
    public class CouponProcessor : ICouponProcessor
    {
        private readonly IDictionary<int, ICouponStrategy> _couponStrategies;
        public CouponProcessor(IEnumerable<ICouponStrategy> couponStrategies) 
        {
            _couponStrategies = couponStrategies.ToDictionary(x => GetCouponIdForStrategy(x), x => x);
        }
        public double ApplyCoupon(int couponId, IEnumerable<ICartItem> shoppingCart, IEnumerable<ICoupon> availableCoupons, double shoppingCartTotal)
        {
            var selectedCoupon = availableCoupons.FirstOrDefault(x => x.Id == couponId);

            if (selectedCoupon != null && _couponStrategies.ContainsKey(couponId))
            {
                var strategy = _couponStrategies[couponId];
                shoppingCartTotal = strategy.ApplyCoupon(shoppingCart, shoppingCartTotal, selectedCoupon);
                // For more coupon strategies we would just need to create a new strategy class + add it to the GetCouponIdForStrategy (below)
                // This breaks Open-Closed principal for GetCouponIdForStrategy
            }
            return shoppingCartTotal; // No valid coupon found
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
