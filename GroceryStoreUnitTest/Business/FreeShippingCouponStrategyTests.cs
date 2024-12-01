using GroceryStore.Business.Classes;
using GroceryStore.Business.Interfaces;
using GroceryStore.Models.Interfaces;
using GroceryStore.Models;

namespace BusinessTests
{
    [TestClass]
    public class FreeShippingCouponStrategyTests
    {
        private ICouponStrategy _couponStrategy;
        private IShoppingCart _shoppingCart;
        private ICoupon _coupon;

        [TestInitialize]
        public void Setup()
        {
            _couponStrategy = new FreeShippingDiscountCouponStrategy();
            _coupon = new Coupon { Id = 3, Name = "FreeShpping", Description = "Free shipping on shopping cart", Discount = 5.0 };
            _shoppingCart = new ShoppingCart { TotalPrice = 100.0, coupon = _coupon };
        }

        [TestMethod]
        public void ApplyCoupon_ShouldApplyDiscountCorrectly()
        {
            var newTotalPrice = _couponStrategy.ApplyCoupon(_shoppingCart);

            var expectedTotalPrice = 95.0;
            Assert.AreEqual(expectedTotalPrice, newTotalPrice);
        }

        [TestMethod]
        public void IsApplicable_ShouldReturnTrue_WhenCouponIdIs1()
        {
            var isApplicable = _couponStrategy.IsApplicable(_coupon);

            Assert.IsTrue(isApplicable);
        }

        [TestMethod]
        public void IsApplicable_ShouldReturnFalse_WhenCouponIdIsNot3()
        {
            _coupon.Id = 2;

            var isApplicable = _couponStrategy.IsApplicable(_coupon);

            Assert.IsFalse(isApplicable);
        }
    }

}
