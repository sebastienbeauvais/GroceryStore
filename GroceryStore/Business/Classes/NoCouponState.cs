using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Models;

namespace GroceryStore.Business.Classes
{
    public class NoCouponState
    {
        public double HandleUserSelection(IEnumerable<CartItem> shoppingCart, double shoppingCartTotal)
        {
            Console.WriteLine("No Coupon Applied");
            return shoppingCartTotal;
        }
    }
}
