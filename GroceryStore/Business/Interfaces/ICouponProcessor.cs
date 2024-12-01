using GroceryStore.Models.Interfaces;

namespace GroceryStore.Business.Interfaces
{
    public interface ICouponProcessor
    {
        public double ApplyCoupon(IShoppingCart shoppingCart);
    }
}
