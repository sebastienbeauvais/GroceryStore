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
        private IEnumerable<ICouponStrategy> _couponStrategies;
        public CouponHandlerHelper(ICouponDb couponDb, IEnumerable<ICouponStrategy> couponStrategies) 
        {
            _couponDb = couponDb.AvailableCoupons;
            _couponStrategies = couponStrategies;
        }
        public ICoupon GetCouponDetails(int couponId)
        {
            var couponDetails = _couponDb.Where(x => x.Id == couponId).First();
            couponDetails.CouponStrategy = GetCouponStrategyForSelectedCoupon(couponDetails);
            return couponDetails;
        }
        public void ShowAvailableCoupons(IEnumerable<ICoupon> availableCoupons)
        {
            foreach (var coupon in availableCoupons)
            {
                Console.WriteLine($"{coupon.Id} - {coupon.Name}, {coupon.Description}");
            }
        }
        private ICouponStrategy GetCouponStrategyForSelectedCoupon(ICoupon coupon)
        {
            return _couponStrategies.FirstOrDefault(s => s.IsApplicable(coupon));
        }
    }
}
