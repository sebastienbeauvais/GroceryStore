using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Business.Interfaces;
using GroceryStore.Models;
using GroceryStore.Models.Interfaces;
using GroceryStore.Data.Interfaces;

namespace GroceryStore.Business.Classes
{
    public class CouponHandler : ICouponHandler
    {
        private ICouponProcessor _couponProcessor;
        private List<ICoupon> _couponDb;
        public CouponHandler(ICouponProcessor couponProcessor, ICouponDb couponDb) 
        {
            _couponProcessor = couponProcessor;
            _couponDb = couponDb.AvailableCoupons;
        }
        public double HandleUserSelection(IShoppingCart shoppingCart)
        {
            string userIn = string.Empty;

            while (userIn != "Y" && userIn != "N")
            {
                Console.WriteLine("\nApply a coupon? (Y/N)");
                userIn = Console.ReadLine().ToUpper();
                if (userIn == "Y")
                {
                    _couponProcessor.ShowAvailableCoupons(_couponDb);
                    Console.WriteLine("Which coupon would you like to apply (enter ID): ");
                    var couponId = Convert.ToInt32(Console.ReadLine());
                    var couponDetails = GetCouponDetails(_couponDb, couponId);
                    shoppingCart.coupon = couponDetails;
                    //use a coupon helper class to get the coupon details
                    // then we can set the shoppingCart.Coupon as an ICoupon instead of an int
                    
                    _couponProcessor.ApplyCoupon(shoppingCart);
                }
                else if (userIn == "N")
                {
                    return shoppingCart.TotalPrice;
                }
                else
                {
                    Console.WriteLine($"Sorry {userIn} is not a valid input. Please enter Y or N.");
                }
            }
            return shoppingCart.TotalPrice;
        }
        private ICoupon GetCouponDetails(List<ICoupon> couponDb, int couponId) 
        {
            var couponDetails = couponDb.Where(x => x.Id == couponId).First();
            return couponDetails;
        }
    }
}
