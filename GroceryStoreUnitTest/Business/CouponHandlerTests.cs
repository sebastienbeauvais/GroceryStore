using GroceryStore.Business.Classes;
using GroceryStore.Business.Interfaces;
using GroceryStore.Models;
using GroceryStoreUnitTest.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.IO;

namespace GroceryStoreUnitTest.Business
{
    [TestClass]
    public class CouponHandlerTests
    {
        private Mock<ICouponProcessor> _mockCouponProcessor;
        private CouponHandler _couponHandler;
        private TestData _testData;

        [TestInitialize]
        public void Setup()
        {
            _mockCouponProcessor = new Mock<ICouponProcessor>();
            _couponHandler = new CouponHandler(_mockCouponProcessor.Object);
            _testData = new TestData();
        }

    }
}
