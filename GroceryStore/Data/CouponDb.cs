using GroceryStore.Data.Interfaces;
using GroceryStore.Models;
using GroceryStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Data
{
    public class CouponDb : ICouponDb
    {
        public List<ICoupon> AvailableCoupons { get; } = new List<ICoupon>
        {
            new Coupon { Id = 1, Name = "10OFF", Description = "Applied 10% off your total cart", Discount = 0.1 },
            new Coupon { Id = 2, Name = "BOGOFree", Description = "Buy one item get one free", Discount = 1.0 },
            new Coupon { Id = 3, Name = "FreeShpping", Description = "Free shipping on shopping cart", Discount = 5.0 },
        };
    }
}
