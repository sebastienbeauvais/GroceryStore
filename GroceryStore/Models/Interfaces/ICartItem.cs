using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Models.Interfaces
{
    public interface ICartItem
    {
        int Id { get; set; }
        String? Name { get; set; }
        int Quantity { get; set; }
        double Price { get; set; }
    }
}
