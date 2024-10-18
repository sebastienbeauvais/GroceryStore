using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Business.Interfaces;
using GroceryStore.Models;
using GroceryStore.Models.Interfaces;

namespace GroceryStore.Business.Classes
{
    public class CouponHandler : ICouponHandler
    {
        private ICouponProcessor _couponProcessor;
        public CouponHandler(ICouponProcessor couponProcessor) 
        {
            _couponProcessor = couponProcessor;
        }

        private List<Coupon> availableCoupons = new List<Coupon>()
        {
            new Coupon { Id = 1, Name = "10OFF", Description = "Applied 10% off your total cart", Discount = 0.1 },
            new Coupon { Id = 2, Name = "BOGOFree", Description = "Buy one item get one free", Discount = 1.0 },
        };
        
        public double HandleUserSelection(IEnumerable<CartItem> shoppingCart, double shoppingCartTotal)
        {
            string userIn = string.Empty;

            while (userIn != "Y" && userIn != "N")
            {
                Console.WriteLine("\nApply a coupon? (Y/N)");
                userIn = Console.ReadLine().ToUpper();
                if (userIn == "Y")
                {
                    _couponProcessor.ShowAvailableCoupons(availableCoupons);
                    Console.WriteLine("Which coupon would you like to apply (enter ID): ");
                    var couponId = Convert.ToInt32(Console.ReadLine());
                    shoppingCartTotal = _couponProcessor.ApplyCoupon(couponId, shoppingCart, availableCoupons, shoppingCartTotal);
                }
                else if (userIn == "N")
                {
                    return shoppingCartTotal;
                }
                else
                {
                    Console.WriteLine($"Sorry {userIn} is not a valid input. Please enter Y or N.");
                }
            }
            return shoppingCartTotal;
        }
    }
}
