using GroceryStore.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Models.Interfaces
{
    public interface IShoppingCart
    {
        IEnumerable<ICartItem> Items { get; set; }
        double TotalPrice { get; set; }
        ICoupon? coupon { get; set; }
    }
}
