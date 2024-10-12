using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Business.Interfaces;
using GroceryStore.Models;

namespace GroceryStore.Business.Classes
{
    public class CouponProcessor : ICouponProcessor
    {
        private readonly IDictionary<int, ICouponStrategy> _couponStrategies;
        public CouponProcessor(IEnumerable<ICouponStrategy> couponStrategies) 
        {
            _couponStrategies = couponStrategies.ToDictionary(x => GetCouponIdForStrategy(x), x => x);
        }
        public double ApplyCoupon(int couponId, IEnumerable<CartItem> shoppingCart, IEnumerable<Coupon> availableCoupons, double shoppingCartTotal)
        {
            /*var selectedCoupon = availableCoupons.FirstOrDefault(x => x.Id == couponId);
            // Apply stategy pattern here and use DI
            if (selectedCoupon != null && selectedCoupon == availableCoupons.FirstOrDefault(x => x.Id == selectedCoupon.Id) && selectedCoupon.Id != 3)
            {
                Console.WriteLine("Applyin coupon...");
                var newCartTotal = shoppingCartTotal - (shoppingCartTotal * selectedCoupon.Discount);
                return newCartTotal;
            }
            else if (selectedCoupon.Id == 3)
            {
                double newCartTotal = 0;
                foreach (var item in shoppingCart)
                {
                    if (item.Quantity % 2 == 0)
                    {
                        var discountItemPrice = (((item.Price * item.Quantity) * selectedCoupon.Discount) * 0.5);
                        newCartTotal += discountItemPrice;
                    }
                    else if (item.Quantity > 2)
                    {
                        var discountItemPrice = (item.Price * (item.Quantity / 2));
                        newCartTotal += (item.Price * item.Quantity) - discountItemPrice;
                    }
                    else
                    {
                        newCartTotal += item.Price;
                    }
                }
                return newCartTotal;
            }
            return 0;*/
            var selectedCoupon = availableCoupons.FirstOrDefault(x => x.Id == couponId);

            if (selectedCoupon != null && _couponStrategies.ContainsKey(couponId))
            {
                var strategy = _couponStrategies[couponId];
                return strategy.ApplyCoupon(shoppingCart, shoppingCartTotal, selectedCoupon);
            }
            return shoppingCartTotal; // No valid coupon found
        }
        public void ShowAvailableCoupons(IEnumerable<Coupon> availableCoupons)
        {
            foreach (var coupon in availableCoupons)
            {
                Console.WriteLine($"{coupon.Id} - {coupon.Name}, {coupon.Description}");
            }
        }
        private int GetCouponIdForStrategy(ICouponStrategy strategy)
        {
            // Map strategies to coupon IDs here. You could also use attributes or configuration to handle this.
            if (strategy is BOGOFreeCouponStrategy) return 3;
            if (strategy is StandardDiscountCouponStrategy) return 1; // Example for a standard discount coupon
                                                                      // Add more mappings as needed.
            throw new InvalidOperationException("Unknown coupon strategy.");
        }
    }
}
