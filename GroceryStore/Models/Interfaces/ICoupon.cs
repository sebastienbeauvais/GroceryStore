﻿using GroceryStore.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Models.Interfaces
{
    public interface ICoupon
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        double Discount { get; set; }
        ICouponStrategy? CouponStrategy { get; set; }
    }
}
