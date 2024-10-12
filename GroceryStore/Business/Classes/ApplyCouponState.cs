using GroceryStore.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Models; // This needs to be updated to intefaces

namespace GroceryStore.Business.Classes
{
    public class ApplyCouponState : IUserSelectionState
    {
        private CouponProcessor couponProcessor;
        private IEnumerable<Coupon> availableCoupons;
        public ApplyCouponState(CouponProcessor couponProcessor, IEnumerable<Coupon> availableCoupons)
        {
            this.couponProcessor = couponProcessor;
            this.availableCoupons = availableCoupons;
        }
        public double HandleUserSelection(IEnumerable<CartItem> shoppingCart, double shoppingCartTotal)
        {
            couponProcessor.ShowAvailableCoupons(availableCoupons);
            Console.WriteLine("Which coupon would you like to apply (enter the ID): ");
            var couponId = Convert.ToInt32(Console.ReadLine());
            return couponProcessor.ApplyCoupon(couponId, shoppingCart, availableCoupons, shoppingCartTotal);
        }
    }
}
