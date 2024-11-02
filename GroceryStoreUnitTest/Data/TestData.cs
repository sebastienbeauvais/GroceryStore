using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Business.Classes;
using GroceryStore.Models;
using GroceryStore.Models.Interfaces;

namespace GroceryStoreUnitTest.Data
{
    public class TestData
    {
        public IEnumerable<Coupon> CreateCouponList()
        {
            var couponList = new List<Coupon>
            {
                new Coupon { Id = 1, Name = "10OFF", Description = "10 off total cart", Discount = 0.10 },
                new Coupon { Id = 2, Name = "20OFF", Description = "20 off total cart", Discount = 0.20 },
                new Coupon { Id = 3, Name = "BOGOFREE", Description = "Buy one get one free", Discount = 1 }
            };
            return couponList;
        }
        public IEnumerable<Coupon> CreateTwoCouponList()
        {
            var couponList = new List<Coupon>
            {
                new Coupon { Id = 1, Name = "10OFF", Description = "10 off total cart", Discount = 0.10 },
                new Coupon { Id = 2, Name = "BOGOFREE", Description = "Buy one get one free", Discount = 1 }
            };
            return couponList;
        }
        public IShoppingCart CreateGeneralShoppingCart()
        {
            IShoppingCart shoppingCart = new ShoppingCart
            {
                Items = new List<ICartItem>
                {
                    new CartItem { Id = 1, Name = "TestItem1", Quantity = 1, Price = 10.0 },
                },
                TotalPrice = 10.0,
                coupon = new Coupon { Id = 1, Discount = 0.1 }
            };

            return shoppingCart;
        }
        public IShoppingCart CreateCartForBogoDiscountShoppingCart_EvenQuantity()
        {
            IShoppingCart shoppingCart = new ShoppingCart
            {
                Items = new List<ICartItem>
                {
                    new CartItem { Id = 1, Name = "TestItem1", Quantity = 2, Price = 10.0 },
                },
                TotalPrice = 20.0,
                coupon = new Coupon { Id = 2, Discount = 0.5 }
            };
            
            return shoppingCart;
        }
        public IShoppingCart CreateCartForBogoDiscountShoppingCart_OddQuantity()
        {
            IShoppingCart shoppingCart = new ShoppingCart
            {
                Items = new List<ICartItem>
                {
                    new CartItem { Id = 1, Name = "TestItem1", Quantity = 3, Price = 10.0 },
                },
                TotalPrice = 30.0,
                coupon = new Coupon { Id = 2, Discount = 0.5 }
            };

            return shoppingCart;
        }
        public IShoppingCart CreateGenericShoppingCart_OneItem_SingleQuantity()
        {
            IShoppingCart shoppingCart = new ShoppingCart
            {
                Items = new List<ICartItem>
                {
                    new CartItem { Id = 1, Name = "TestItem1", Quantity = 1, Price = 10.0 },
                },
                TotalPrice = 10.0,
                coupon = new Coupon { Id = 2, Discount = 0.5 }
            };

            return shoppingCart;
        }
        public Coupon CreateBogoCoupon()
        {
            var coupon = new Coupon { Id = 3, Discount = 1 };
            return coupon;
        }
        public Coupon CreateTenOffCoupon()
        {
            var coupon = new Coupon { Id = 1, Name = "10OFF", Description = "Applied 10% off your total cart", Discount = 0.1 };
            return coupon;
        }
    }
}
