using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Business.Interfaces
{
    public interface ICouponProcessor
    {
        public double ApplyCoupon(int couponId, IEnumerable<CartItem> shoppingCart, IEnumerable<Coupon> availableCoupons, double shoppingCartTotal);
    }
}
