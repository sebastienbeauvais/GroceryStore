using GroceryStore.Business.Classes;
using GroceryStore.Business.Interfaces;
using GroceryStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using GroceryStoreUnitTest.Data;

namespace GroceryStoreUnitTest
{
    [TestClass]
    public class ApplyCouponStateTests
    {
        private Mock<ICouponProcessor> _couponProcessorMock;
        private IEnumerable<Coupon> _availableCoupons;
        private ApplyCouponState _applyCouponState;
        private TestData _testData;
        [TestInitialize]
        public void SetUp()
        {
            _couponProcessorMock = new Mock<ICouponProcessor>();
            _availableCoupons = new List<Coupon>
            {
                new Coupon { Id = 1, Name = "10OFF", Description = "10 off total cart", Discount = 0.10 },
                new Coupon { Id = 2, Name = "20OFF", Description = "20 off total cart", Discount = 0.20 },
                new Coupon { Id = 3, Name = "BOGOFREE", Description = "Buy one get one free", Discount = 0.50 }
            };
            _testData = new TestData();

            _applyCouponState = new ApplyCouponState(_couponProcessorMock.Object, _availableCoupons);
            
        }
        [TestMethod]
        public void HandleUserSelection_ApplyValidCoupon()
        {
            var shoppingCart = _testData.CreateGeneralShoppingCartList();
            double shoppingCartTotal = 10.0;

            var couponId = 1;
            Console.SetIn(new System.IO.StringReader(couponId.ToString())); //Note sure why, but this leaving this out breaks the tes

            _couponProcessorMock.Setup(x => x.ApplyCoupon(couponId, shoppingCart, _availableCoupons, shoppingCartTotal))
                                .Returns(shoppingCartTotal - (shoppingCartTotal * 0.10));

            var newTotal = _applyCouponState.HandleUserSelection(shoppingCart, shoppingCartTotal);

            Assert.AreEqual(9.0, newTotal);
        }
        [TestMethod]
        public void HandleUserSelection_ApplyCouponStateWhenInvalidCouponIsProvided()
        {
            var shoppingCart = _testData.CreateGeneralShoppingCartList();
            double shoppingCartTotal = 10.0;

            var couponId = 99;
            Console.SetIn(new System.IO.StringReader(couponId.ToString())); //Note sure why, but this leaving this out breaks the tes

            _couponProcessorMock.Setup(x => x.ApplyCoupon(couponId, shoppingCart, _availableCoupons, shoppingCartTotal))
                                .Returns(shoppingCartTotal);

            var newTotal = _applyCouponState.HandleUserSelection(shoppingCart, shoppingCartTotal);

            Assert.AreEqual(10.0, newTotal);

        }
    }
}