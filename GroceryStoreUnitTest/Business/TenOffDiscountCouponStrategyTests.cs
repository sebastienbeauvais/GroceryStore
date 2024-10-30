using GroceryStore.Business.Classes;
using GroceryStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using GroceryStoreUnitTest.Data;

namespace GroceryStoreUnitTest.Business
{
    [TestClass]
    public class TenOffDiscountCouponStrategyTests
    {
        private TenOffDiscountCouponStrategy _strategy;
        private TestData _testData;

        [TestInitialize]
        public void Setup()
        {
            _strategy = new TenOffDiscountCouponStrategy();
            _testData = new TestData();

        }

        [TestMethod]
        public void ApplyCoupon_WithTenPercentDiscount_AppliesCorrectDiscount()
        {
            double initialTotal = 10.0;
            var coupon = _testData.CreateTenOffCoupon();
            var cartItems = _testData.CreateGeneralShoppingCartList();

            var result = _strategy.ApplyCoupon(cartItems, initialTotal, coupon);

            Assert.AreEqual(9.0, result, "Expected 10% discount to be applied to the total.");
        }

        [TestMethod]
        public void ApplyCoupon_WithZeroTotal_ReturnsZero()
        {
            double initialTotal = 0.0;
            var coupon = _testData.CreateTenOffCoupon();
            var cartItems = new List<CartItem>();

            var result = _strategy.ApplyCoupon(cartItems, initialTotal, coupon);

            Assert.AreEqual(0.0, result, "Expected total to remain zero when initial total is zero.");
        }
    }
}
