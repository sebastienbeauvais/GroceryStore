using GroceryStore.Business.Interfaces;
using GroceryStore.Models.Interfaces;
using GroceryStore.Data.Interfaces;

namespace GroceryStore.Business.Classes
{
    public class CouponHandler : ICouponHandler
    {
        private ICouponProcessor _couponProcessor;
        private List<ICoupon> _couponDb;
        private IEnumerable<ICouponStrategy> _couponStrategies;
        public CouponHandler(ICouponProcessor couponProcessor, ICouponDb couponDb, IEnumerable<ICouponStrategy> couponStratgies)
        {
            _couponProcessor = couponProcessor;
            _couponDb = couponDb.AvailableCoupons;
            _couponStrategies = couponStratgies;
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
                    ShowAvailableCoupons();
                    Console.WriteLine("Which coupon would you like to apply (enter ID): ");
                    var couponId = Convert.ToInt32(Console.ReadLine());
                    shoppingCart.coupon = GetCouponDetails(couponId);
                    //decorator pattern - tailor made for this processing
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
        private void ShowAvailableCoupons()
        {
            foreach (var coupon in _couponDb)
            {
                Console.WriteLine($"{coupon.Id} - {coupon.Name}, {coupon.Description}");
            }
        }
        private ICoupon GetCouponDetails(int couponId)
        {
            var couponDetails = _couponDb.Where(x => x.Id == couponId).First();
            couponDetails.CouponStrategy = GetCouponStrategyForSelectedCoupon(couponDetails);
            return couponDetails;
        }
        private ICouponStrategy GetCouponStrategyForSelectedCoupon(ICoupon coupon)
        {
            //add try catch here
            return _couponStrategies.First(s => s.IsApplicable(coupon));
        }
    }
}
