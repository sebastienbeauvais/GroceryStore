using GroceryStore.Models.Interfaces;

namespace GroceryStore.Business.Interfaces
{
    public interface ICouponStrategy
    {
        double ApplyCoupon(IShoppingCart shoppingCart);
        bool IsApplicable(ICoupon coupon);
    }
}
