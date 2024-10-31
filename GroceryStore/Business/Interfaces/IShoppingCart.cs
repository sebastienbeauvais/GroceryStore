using GroceryStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Business.Interfaces
{
    public interface IShoppingCart
    {
        IEnumerable<ICartItem> Items { get; set; }
        double TotalPrice { get; set; }
        ICoupon? coupon { get; set; }
    }
}
