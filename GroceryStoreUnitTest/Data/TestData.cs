using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Models;

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
                new Coupon { Id = 3, Name = "BOGOFREE", Description = "Buy one get one free", Discount = 0.50 }
            };
            return couponList;
        }
        public List<CartItem> CreateGeneralShoppingCartList()
        {
            var cartItemList = new List<CartItem>
            {
                new CartItem { Id = 1, Name = "TestItem1", Quantity = 1, Price = 10.0 },
            };
            return cartItemList;
        }
        public List<CartItem> CreateCartForBogoDiscountEvenQuantity()
        {
            var cartItemList = new List<CartItem>
            {
                new CartItem { Id = 1, Name = "TestItem1", Quantity = 2, Price = 10.0 },
            };
            return cartItemList;
        }
        public List<CartItem> CreateCartForBogoDiscountOddQuantity()
        {
            var cartItemList = new List<CartItem>
            {
                new CartItem { Id = 1, Name = "TestItem1", Quantity = 3, Price = 10.0 },
            };
            return cartItemList;
        }
        public Coupon CreateBogoCoupon()
        {
            var coupon = new Coupon { Id = 3, Discount = 1 };
            return coupon;
        }
    }
}
