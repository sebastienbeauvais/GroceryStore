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
        private ICouponHandlerHelper _couponHandlerHelper;
        public CouponHandler(ICouponProcessor couponProcessor, ICouponDb couponDb, ICouponHandlerHelper couponHandlerHelper)
        {
            _couponProcessor = couponProcessor;
            _couponDb = couponDb.AvailableCoupons;
            _couponHandlerHelper = couponHandlerHelper;
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
                    
                    _couponHandlerHelper.ShowAvailableCoupons(_couponDb);
                    Console.WriteLine("Which coupon would you like to apply (enter ID): ");
                    var couponId = Convert.ToInt32(Console.ReadLine());
                    shoppingCart.coupon = _couponHandlerHelper.GetCouponDetails(couponId);
                    
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
            // An idea: you are accepting the id of a coupon from User In.
            // Use the id to get the details
            // Then set on the shopping cart and we apply the coupon
            // What if the super market becomes huge and DB of coupons becomes huge
            // Now Apply Coupon goes over every strategy
            // This is a scaling problem
            // What we can see: On the coupon Handler -> when they type in coupon 2 
            // Instead of getting details return the strategy and return that so when we 
            // process the cart we already are ready to go
        }
    }
}
