using GroceryStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStore.Data.Interfaces
{
    public interface IStoreInventoryDb
    {
        List<IStoreItem> Inventory { get; }
    }
}
