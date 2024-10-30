using GroceryStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Business.Interfaces
{
    public interface ICouponStrategy
    {
        double ApplyCoupon(IEnumerable<ICartItem> shoppingCart, double shoppingCartTotal, ICoupon coupon);
    }
}
