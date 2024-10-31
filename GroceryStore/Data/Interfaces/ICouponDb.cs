using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStore.Models.Interfaces;

namespace GroceryStore.Data.Interfaces
{
    public interface ICouponDb
    {
        List<ICoupon> AvailableCoupons { get; } 
    }
}
