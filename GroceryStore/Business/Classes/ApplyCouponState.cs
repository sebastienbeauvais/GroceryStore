using GroceryStore.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Models.Interfaces; // This needs to be updated to intefaces
using GroceryStore.Models;

namespace GroceryStore.Business.Classes
{
    public class ApplyCouponState : IUserSelectionState
    {
        private ICouponProcessor _couponProcessor;
        private IEnumerable<Coupon> _availableCoupons;
        public ApplyCouponState(ICouponProcessor couponProcessor, IEnumerable<Coupon> availableCoupons)
        {
            _couponProcessor = couponProcessor;
            _availableCoupons = availableCoupons;
        }
        public double HandleUserSelection(IEnumerable<CartItem> shoppingCart, double shoppingCartTotal)
        {
            _couponProcessor.ShowAvailableCoupons(_availableCoupons);
            Console.WriteLine("Which coupon would you like to apply (enter the ID): ");
            var couponId = Convert.ToInt32(Console.ReadLine());
            return _couponProcessor.ApplyCoupon(couponId, shoppingCart, _availableCoupons, shoppingCartTotal);
        }
    }
}
