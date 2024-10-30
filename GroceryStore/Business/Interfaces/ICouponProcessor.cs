using GroceryStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Business.Interfaces
{
    public interface ICouponProcessor
    {
        public double ApplyCoupon(int couponId, IEnumerable<ICartItem> shoppingCart, IEnumerable<ICoupon> availableCoupons, double shoppingCartTotal);
        public void ShowAvailableCoupons(IEnumerable<ICoupon> availableCoupons);
    }
}
