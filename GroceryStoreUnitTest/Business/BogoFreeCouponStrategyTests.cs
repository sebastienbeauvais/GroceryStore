using Microsoft.VisualStudio.TestTools.UnitTesting;
using GroceryStore.Business.Classes;
using GroceryStore.Models;
using System.Collections.Generic;
using GroceryStoreUnitTest.Data;

namespace BusinessTests
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
            var shoppingCart = _testData.CreateCartForBogoDiscountShoppingCart_EvenQuantity();

            var newCartTotal = _bogoFreeCouponStrategy.ApplyCoupon(shoppingCart);

            Assert.AreEqual(10.0, newCartTotal);
        }

        [TestMethod]
        public void Test_BogoFreeCouponStrategy_WithOddQuantity_AppliesPartialDiscount()
        {
            var shoppingCart = _testData.CreateCartForBogoDiscountShoppingCart_OddQuantity();

            var newCartTotal = _bogoFreeCouponStrategy.ApplyCoupon(shoppingCart);

            Assert.AreEqual(20.0, newCartTotal);
        }

        [TestMethod]
        public void Test_BogoFreeCouponStrategy_WithSingleItem_NoDiscount()
        {
            var shoppingCart = _testData.CreateGenericShoppingCart_OneItem_SingleQuantity();

            var newCartTotal = _bogoFreeCouponStrategy.ApplyCoupon(shoppingCart);

            Assert.AreEqual(10.0, newCartTotal);
        }
    }
}
