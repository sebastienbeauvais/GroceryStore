using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroceryStore.Business.Classes;
using GroceryStore.Models;
using System.Collections.Generic;
using GroceryStoreUnitTest.Data;

namespace GroceryStoreUnitTest
{
    [TestClass]
    public class BogoFreeCouponStrategyTests
    {
        private BogoFreeCouponStrategy _bogoFreeCouponStrategy;
        private TestData _testData;

        [TestInitialize]
        public void Setup()
        {
            _bogoFreeCouponStrategy = new BogoFreeCouponStrategy();
            _testData = new TestData();
        }

        [TestMethod]
        public void Test_BogoFreeCouponStrategy_WithEvenQuantity_AppliesDiscount()
        {
            var shoppingCart = _testData.CreateCartForBogoDiscountEvenQuantity();
            var coupon = _testData.CreateBogoCoupon();
            double shoppingCartTotal = 20.0;

            var newCartTotal = _bogoFreeCouponStrategy.ApplyCoupon(shoppingCart, shoppingCartTotal, coupon);

            Assert.AreEqual(10.0, newCartTotal);
        }

        [TestMethod]
        public void Test_BogoFreeCouponStrategy_WithOddQuantity_AppliesPartialDiscount()
        {
            var shoppingCart = _testData.CreateCartForBogoDiscountOddQuantity();
            var coupon = _testData.CreateBogoCoupon();
            double shoppingCartTotal = 30.0;

            var newCartTotal = _bogoFreeCouponStrategy.ApplyCoupon(shoppingCart, shoppingCartTotal, coupon);

            Assert.AreEqual(20.0, newCartTotal);
        }

        [TestMethod]
        public void Test_BogoFreeCouponStrategy_WithSingleItem_NoDiscount()
        {
            var shoppingCart = _testData.CreateGeneralShoppingCartList();
            var coupon = _testData.CreateBogoCoupon();
            double shoppingCartTotal = 10.0;

            var newCartTotal = _bogoFreeCouponStrategy.ApplyCoupon(shoppingCart, shoppingCartTotal, coupon);

            Assert.AreEqual(10.0, newCartTotal);
        }
    }
}
