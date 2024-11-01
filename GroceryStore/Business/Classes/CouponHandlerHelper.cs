using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Business.Interfaces;
using GroceryStore.Models.Interfaces;
using GroceryStore.Data.Interfaces;

namespace GroceryStore.Business.Classes
{
    public class CouponHandlerHelper : ICouponHandlerHelper
    {
        private List<ICoupon> _couponDb;
        public CouponHandlerHelper(ICouponDb couponDb) 
        {
            _couponDb = couponDb.AvailableCoupons;
        }
        public ICoupon GetCouponDetails(List<ICoupon> couponDb, int couponId)
        {
            var couponDetails = couponDb.Where(x => x.Id == couponId).First();
            return couponDetails;
        }
        public void ShowAvailableCoupons(IEnumerable<ICoupon> availableCoupons)
        {
            foreach (var coupon in availableCoupons)
            {
                Console.WriteLine($"{coupon.Id} - {coupon.Name}, {coupon.Description}");
            }
        }
    }
}
