using GroceryStore.Models.Interfaces;

namespace GroceryStore.Business.Interfaces
{
    public interface ICouponHandlerHelper
    {
        public ICoupon GetCouponDetails(int couponId);
        public void ShowAvailableCoupons(IEnumerable<ICoupon> availableCoupons);
    }
}